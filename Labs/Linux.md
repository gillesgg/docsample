# Windows / WLS installation

## Install winget tool
https://www.microsoft.com/p/app-installer/9nblggh4nns1#activetab=pivot:overviewtab

# Install Windows Terminal
From cmd or PowerShell start
winget install Microsoft.WindowsTerminal -y

# Install PowerShell Core
winget install -e --id Microsoft.PowerShell

# WSL installation
From cmd or PowerShell start
wsl --install -d Ubuntu-22.04

# Optional - oh-my-posh Windows PowerShell installation
From cmd or PowerShell start follow the instructions
https://ohmyposh.dev/docs/installation/windows
https://www.hanselman.com/blog/my-ultimate-powershell-prompt-with-oh-my-posh-and-the-windows-terminal

# Edit and update PowerShell profile
$PROFILE

oh-my-posh init pwsh | Invoke-Expression
& ([ScriptBlock]::Create((oh-my-posh init pwsh --config "$env:POSH_THEMES_PATH\amro.omp.json" --print) -join "`n"))
Import-Module -Name Terminal-Icons

# Optional - oh-my-posh WSL installation

sudo apt install unzip

https://ohmyposh.dev/docs/installation/wsl
https://calebschoepp.com/blog/2021/how-to-setup-oh-my-posh-on-ubuntu/


# Install .NET 8 SDK on WSL
https://learn.microsoft.com/en-us/dotnet/core/install/linux-ubuntu#register-the-microsoft-package-repository

// Get Ubuntu version
declare repo_version=$(if command -v lsb_release &> /dev/null; then lsb_release -r -s; else grep -oP '(?<=^VERSION_ID=).+' /etc/os-release | tr -d '"'; fi)
// Download Microsoft signing key and repository
wget https://packages.microsoft.com/config/ubuntu/$repo_version/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
// Install Microsoft signing key and repository
sudo dpkg -i packages-microsoft-prod.deb
// Clean up
rm packages-microsoft-prod.deb
// Update packages
sudo apt update

// install .NET 8 SDK
sudo apt install dotnet-sdk-8.0

// use dotnet --list-sdks to show the sdk version
dotnet --list-sdks 

//sudo apt-get remove dotnet-sdk-8.0

# Install VSCode remote

code .

## Install VSCode extension
C# Dev Kit
C#

# Install .NET Tools

dotnet tool install --global dotnet-monitor
dotnet tool install --global dotnet-counters
dotnet tool install --global dotnet-dump
dotnet tool install --global dotnet-gcdump
dotnet tool install --global dotnet-trace
dotnet tool install --global dotnet-stack
dotnet tool install --global dotnet-symbol
dotnet tool install --global dotnet-sos

# Install procdump 

https://github.com/Sysinternals/ProcDump-for-Linux/blob/master/INSTALL.md

# Install lldb

https://github.com/dotnet/diagnostics/blob/main/documentation/lldb/linux-instructions.md

lldb fix
sudo ln -s /usr/lib/llvm-14/lib/python3.10/dist-packages/lldb/* /usr/lib/python3/dist-packages/lldb/
