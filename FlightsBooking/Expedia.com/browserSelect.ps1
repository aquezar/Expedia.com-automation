param([string]$browser="Chrome")
$config = 'App.config'
$doc = (Get-Content $config) -as [xml]
$node = $doc.configuration.appSettings.add | where {$_.key -eq "Browser"}
$node.value = $browser
$doc.Save("$pwd\$config")
