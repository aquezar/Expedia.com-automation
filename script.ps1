[xml]$doc = Get-Content TestResult.xml
$case = $doc.'test-results'.'test-suite'.results.'test-suite'.results.'test-suite'.results.'test-suite'.results.'test-suite'.results.'test-suite'.results.'test-case'
$target = ($case|where-object {$_.result -eq "Error"})
$target.name > results.txt