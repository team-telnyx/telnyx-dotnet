#!/usr/bin/env python3
"""Release entrypoint: verification BEFORE any staging/build/pack side effect.
The separate compat/build_diagnostic_candidate.py is never called here.
"""
from pathlib import Path
import runpy
import sys

if __name__ == '__main__':
    gate = runpy.run_path(str(Path(__file__).with_name('verify-generated.py')))
    sys.exit(gate['main']())
