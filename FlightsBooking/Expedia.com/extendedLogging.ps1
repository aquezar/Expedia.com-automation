param([string]$logging="True")
$config = 'App.config'
$doc = (Get-Content $config) -as [xml]
$node = $doc.configuration.appSettings.add | where {$_.key -eq "ExtendedLogging"}
$node.value = $logging
$doc.Save("$pwd\$config")
