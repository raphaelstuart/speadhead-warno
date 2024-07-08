param($unitName)
$guid = [guid]::NewGuid()
$uid = $unitName.replace('Descriptor_Unit_', '')

Write-Host "Descriptor_Deck_Pack_$uid is TDeckPackDescriptor"
Write-Host "("
Write-Host "    DescriptorId = GUID:{$guid}"
Write-Host "    CfgName = 'TOE_$uid'"
Write-Host "    TransporterAndUnitsList ="
Write-Host "    ["
Write-Host "        TDeckTransporterAndUnitsDescriptor"
Write-Host "        ("
Write-Host "            UnitDescriptor = $/GFX/Unit/$unitName"
Write-Host "        ),"
Write-Host "    ]"
Write-Host ")"
