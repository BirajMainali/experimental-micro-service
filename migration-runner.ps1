# Get all the directories containing a .csproj file
$dirs = Get-ChildItem -Path . -Recurse -Filter *.csproj | ForEach-Object { $_.DirectoryName } | Get-Unique

# Iterate over each directory
foreach ($dir in $dirs) {
    # Change to the directory of the .csproj file
    Set-Location -Path $dir

    # Define the dotnet ef migrations add command as a string
    $command = 'dotnet ef migrations add InitialCreate'

    # Run the command
    Invoke-Expression $command
}S