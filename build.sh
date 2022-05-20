#!/usr/bin/env bash
set -euo pipefail

mkdir -p output

# The normal build
dotnet build -c Release \
    -p:OutputPath=../output/
