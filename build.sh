#!/usr/bin/env bash
set -euo pipefail

mkdir -p output

# The normal build
dotnet build -c Release \
    -p:OutputPath=../output/without-submerged/

dotnet build -c Release \
    -p:DefineConstants=SUBMERGED \
    -p:OutputPath=../output/with-submerged/
