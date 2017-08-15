param([string]$lightweight="False")
$config = 'App.config'
$doc = (Get-Content $config) -as [xml]
$node = $doc.configuration.appSettings.add | where {$_.key -eq "LightweightMode"}
$node.value = $lightweight
$doc.Save("$pwd\$config")
