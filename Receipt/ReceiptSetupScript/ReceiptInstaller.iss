; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!


[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{25605D0B-E325-44D9-A7C3-8017F24F2D2C}
AppName=Receipt
AppVersion=1.0.0.1
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher=niksSoft
DefaultDirName={autopf}\Receipt
ChangesAssociations=yes
DisableProgramGroupPage=yes
; Uncomment the following line to run in non administrative install mode (install for current user only.)
;PrivilegesRequired=lowest
OutputDir=D:\Projects\Karanavti5\Receipt\Receipt\bin\Debug
OutputBaseFilename=Receipt
Compression=lzma
SolidCompression=yes
WizardStyle=modern

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "D:\Projects\Karanavti5\Receipt\Receipt\bin\Debug\*"; Excludes: "*.BIN,*.pdb,*.ecw"; DestDir: "{app}"; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Registry]
Root: HKA; Subkey: "Software\Classes\.myp\OpenWithProgids"; ValueType: string; ValueName: "ReceiptFile.myp"; ValueData: ""; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\ReceiptFile.myp"; ValueType: string; ValueName: ""; ValueData: "Receipt File"; Flags: uninsdeletekey
Root: HKA; Subkey: "Software\Classes\ReceiptFile.myp\DefaultIcon"; ValueType: string; ValueName: ""; ValueData: "{app}\MyProg.exe,0"
Root: HKA; Subkey: "Software\Classes\ReceiptFile.myp\shell\open\command"; ValueType: string; ValueName: ""; ValueData: """{app}\MyProg.exe"" ""%1"""
Root: HKA; Subkey: "Software\Classes\Applications\MyProg.exe\SupportedTypes"; ValueType: string; ValueName: ".myp"; ValueData: ""

[Icons]
Name: "{autoprograms}\Receipt"; Filename: "{app}\MyProg.exe"
Name: "{autodesktop}\Receipt"; Filename: "{app}\MyProg.exe"; Tasks: desktopicon

[Run]
Filename: "{app}\MyProg.exe"; Description: "{cm:LaunchProgram,Receipt}"; Flags: nowait postinstall skipifsilent