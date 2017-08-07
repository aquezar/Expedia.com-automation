[xml]$doc = Get-Content TestResult.xml
$failed = $doc.'test-results'.'test-suite'.results.'test-suite'.results.'test-suite'.results.'test-suite'.results.'test-suite'.results.'test-suite'.results.'test-case'.name > results.txt
