[xml]$doc = Get-Content TestResult.xml
$failed = "TestToRun=" + $doc.'test-results'.'test-suite'.results.'test-suite'.results.'test-suite'.results.'test-suite'.results.'test-suite'.results.'test-suite'.results.'test-case'.name > res.txt