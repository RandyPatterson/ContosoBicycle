param (
    [string]$webConfig = "c:\inetpub\wwwroot\Web.config"
)




iisreset stop
Write-Host

$doc = (Get-Content $webConfig) -as [Xml];
$modified = $FALSE;

$appSettingPrefix = "APPSETTING_";
$connectionStringPrefix = "CONNSTR_";

Get-ChildItem env:* | ForEach-Object {
    if ($_.Key.StartsWith($appSettingPrefix)) {
        $modified = $TRUE;
        $key = $_.Key.Substring($appSettingPrefix.Length);
        $appSetting = $doc.configuration.appSettings.add | Where-Object {$_.key -eq $key};
        if ($appSetting) {
            $appSetting.value = $_.Value;
            Write-Host "Replaced appSetting" $_.Key $_.Value;

        } else {
            $newElement = $doc.CreateElement("add");
            $add = $doc.configuration.appSettings.AppendChild($newElement);
            $add.SetAttribute("key",$key);
            $add.SetAttribute("value", $_.Value);
            Write-Host "Added appSetting" $_.Key $_.Value;
           
        }
    }
    if ($_.Key.StartsWith($connectionStringPrefix)) {
        $modified = $TRUE;
        $key = $_.Key.Substring($connectionStringPrefix.Length);
        $connStr = $doc.configuration.connectionStrings.add | Where-Object {$_.name -eq $key};
        if ($connStr) {
            $connStr.connectionString = $_.Value;
            Write-Host "Replaced connectionString" $_.Key $_.Value;
        } else {
            $newElement = $doc.CreateElement("add");
            $add = $doc.configuration.connectionStrings.AppendChild($newElement);
            $add.SetAttribute("name",$key);
            $add.SetAttribute("connectionString", $_.Value);
            Write-Host "Added connectionString" $_.Key $_.Value;
        }
    }
}

if ($modified) {
    $doc.Save($webConfig);
}

iisreset start