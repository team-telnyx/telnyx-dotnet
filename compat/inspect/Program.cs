using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using System.Text.Json;
var rows = args.Select(path => {
 var name=AssemblyName.GetAssemblyName(path);
 using var pe=new PEReader(File.OpenRead(path));
 var md=pe.GetMetadataReader();
 var a=md.GetAssemblyDefinition();
 string FullName(TypeDefinitionHandle h) { var t=md.GetTypeDefinition(h); return t.IsNested ? FullName(t.GetDeclaringType())+"+"+md.GetString(t.Name) : (md.GetString(t.Namespace)+"."+md.GetString(t.Name)).TrimStart('.'); }
 return new {path, identity=name.FullName, publicKey=Convert.ToHexString(name.GetPublicKey() ?? Array.Empty<byte>()), token=Convert.ToHexString(name.GetPublicKeyToken() ?? Array.Empty<byte>()), assemblyFlags=a.Flags.ToString(), corFlags=pe.PEHeaders.CorHeader!.Flags.ToString(), strongNameSignatureSize=pe.PEHeaders.CorHeader.StrongNameSignatureDirectory.Size, sha256=Convert.ToHexString(SHA256.HashData(File.ReadAllBytes(path))).ToLowerInvariant(), references=md.AssemblyReferences.Select(h=>{var r=md.GetAssemblyReference(h);return new {name=md.GetString(r.Name),version=r.Version.ToString(),token=Convert.ToHexString(md.GetBlobBytes(r.PublicKeyOrToken))};}).ToArray(),types=md.TypeDefinitions.Select(h=>{var t=md.GetTypeDefinition(h); return new {name=FullName(h),visibility=(t.Attributes & TypeAttributes.VisibilityMask).ToString()};}).Where(t=>t.visibility=="Public" || t.visibility=="NestedPublic" || t.visibility=="NestedFamily" || t.visibility=="NestedFamORAssem").ToArray()};
}).ToArray();
Console.WriteLine(JsonSerializer.Serialize(rows,new JsonSerializerOptions{WriteIndented=true}));
