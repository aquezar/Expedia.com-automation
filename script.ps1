[xml]$doc = Get-Content TestResult.xml
$failed = $doc.'test-results'.'test-suite'.results.'test-suite'.results.'test-suite'.results.'test-suite'.results.'test-suite'.results.'test-suite'.results.'test-case'.name
$pos = $failed.Indexof("(")
$result = $failed.Substring(0, $pos)
echo "TestToRun = $result" | Out-File -Encoding "ASCII" result.parameters