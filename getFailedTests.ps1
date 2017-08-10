[xml]$doc = Get-Content TestResult.xml
$case = $doc.'test-results'.'test-suite'.results.'test-suite'.results.'test-suite'.results.'test-suite'.results.'test-suite'.results.'test-suite'.results.'test-case'
$target = ($case|where-object {$_.success -eq "False"})
$target.name > failed_test.txt