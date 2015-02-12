VERSION 5.00
Begin VB.Form DismMain 
   Caption         =   "Runtime Express .net Framework Offline Installer"
   ClientHeight    =   3585
   ClientLeft      =   120
   ClientTop       =   465
   ClientWidth     =   7065
   BeginProperty Font 
      Name            =   "Î¢ÈíÑÅºÚ"
      Size            =   9
      Charset         =   134
      Weight          =   400
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   3585
   ScaleWidth      =   7065
   StartUpPosition =   2  'ÆÁÄ»ÖÐÐÄ
   Begin VB.CommandButton Command2 
      Caption         =   "ÒÆ³ý"
      Height          =   615
      Left            =   3600
      TabIndex        =   2
      Top             =   1080
      Width           =   3255
   End
   Begin VB.CommandButton Command1 
      Caption         =   "°²×°"
      Height          =   615
      Left            =   120
      TabIndex        =   1
      Top             =   1080
      Width           =   3255
   End
   Begin VB.Label Label2 
      Caption         =   $"DismMain.frx":0000
      Height          =   1095
      Left            =   240
      TabIndex        =   3
      Top             =   2280
      Width           =   6615
   End
   Begin VB.Label Label1 
      Caption         =   ".net Framework ÀëÏßÌí¼Ó¹¤¾ß"
      BeginProperty Font 
         Name            =   "Î¢ÈíÑÅºÚ Light"
         Size            =   26.25
         Charset         =   134
         Weight          =   290
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   855
      Left            =   0
      TabIndex        =   0
      Top             =   0
      Width           =   6975
   End
End
Attribute VB_Name = "DismMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Declare Function GetWindowsDirectory Lib "kernel32" Alias "GetWindowsDirectoryA" (ByVal lpBuffer As String, ByVal nSize As Long) As Long

Private Sub Command1_Click()
    Dim SysPath As String
    SysPath = String(256, Chr(0))
    GetWindowsDirectory s, 256
    SysPath = Replace(s, Chr(0), "")
    Shell (SysPath & "\system32\dism.exe /online /enable-feature /featurename:netfx3 /Source:" & App.Path & "\image")
End Sub

Private Sub Command2_Click()
    Dim SysPath As String
    SysPath = String(256, Chr(0))
    GetWindowsDirectory s, 256
    SysPath = Replace(s, Chr(0), "")
    Shell (SysPath & "\system32\dism.exe /online /enable-feature /featurename:netfx3 /Remove")
End Sub
