﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.34014
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace My
    
    <Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0"),  _
     Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
    Partial Friend NotInheritable Class MySettings
        Inherits Global.System.Configuration.ApplicationSettingsBase
        
        Private Shared defaultInstance As MySettings = CType(Global.System.Configuration.ApplicationSettingsBase.Synchronized(New MySettings()),MySettings)
        
#Region "My.Settings Auto-Save Functionality"
#If _MyType = "WindowsForms" Then
    Private Shared addedHandler As Boolean

    Private Shared addedHandlerLockObject As New Object

    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
    Private Shared Sub AutoSaveSettings(ByVal sender As Global.System.Object, ByVal e As Global.System.EventArgs)
        If My.Application.SaveMySettingsOnExit Then
            My.Settings.Save()
        End If
    End Sub
#End If
#End Region
        
        Public Shared ReadOnly Property [Default]() As MySettings
            Get
                
#If _MyType = "WindowsForms" Then
               If Not addedHandler Then
                    SyncLock addedHandlerLockObject
                        If Not addedHandler Then
                            AddHandler My.Application.Shutdown, AddressOf AutoSaveSettings
                            addedHandler = True
                        End If
                    End SyncLock
                End If
#End If
                Return defaultInstance
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Data Source=HET-PC\SQLEXPRESS;Initial Catalog=Abcd;Integrated Security=True")>  _
        Public ReadOnly Property AbcdConnectionString() As String
            Get
                Return CType(Me("AbcdConnectionString"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Abcd.mdf;Integrated Sec"& _ 
            "urity=True;Connect Timeout=30;User Instance=True")>  _
        Public ReadOnly Property AbcdConnectionString1() As String
            Get
                Return CType(Me("AbcdConnectionString1"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\bin\Debug\NewDB.mdf;Int"& _ 
            "egrated Security=True;Connect Timeout=30;User Instance=True")>  _
        Public ReadOnly Property NewDBConnectionString() As String
            Get
                Return CType(Me("NewDBConnectionString"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\bin\Debug\DesaiNewDb.md"& _ 
            "f;Integrated Security=True;Connect Timeout=30;User Instance=True")>  _
        Public ReadOnly Property DesaiNewDbConnectionString() As String
            Get
                Return CType(Me("DesaiNewDbConnectionString"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Data Source=.\SQLEXPRESS;AttachDbFilename=""|DataDirectory|\bin\Debug\Het DesaiNew"& _ 
            "Db.mdf"";Integrated Security=True;Connect Timeout=30;User Instance=True")>  _
        Public ReadOnly Property Het_DesaiNewDbConnectionString() As String
            Get
                Return CType(Me("Het_DesaiNewDbConnectionString"),String)
            End Get
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("ActiveCaption")>  _
        Public Property Masterbkcolor() As Global.System.Drawing.Color
            Get
                Return CType(Me("Masterbkcolor"),Global.System.Drawing.Color)
            End Get
            Set
                Me("Masterbkcolor") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Purple")>  _
        Public Property Comcolor() As Global.System.Drawing.Color
            Get
                Return CType(Me("Comcolor"),Global.System.Drawing.Color)
            End Get
            Set
                Me("Comcolor") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Navy")>  _
        Public Property Titlecolor() As Global.System.Drawing.Color
            Get
                Return CType(Me("Titlecolor"),Global.System.Drawing.Color)
            End Get
            Set
                Me("Titlecolor") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Microsoft Sans Serif, 14.25pt, style=Bold, Italic")>  _
        Public Property titlefont() As Global.System.Drawing.Font
            Get
                Return CType(Me("titlefont"),Global.System.Drawing.Font)
            End Get
            Set
                Me("titlefont") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Control")>  _
        Public Property contbackColor() As Global.System.Drawing.Color
            Get
                Return CType(Me("contbackColor"),Global.System.Drawing.Color)
            End Get
            Set
                Me("contbackColor") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Microsoft Sans Serif, 8.25pt")>  _
        Public Property contFont() As Global.System.Drawing.Font
            Get
                Return CType(Me("contFont"),Global.System.Drawing.Font)
            End Get
            Set
                Me("contFont") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Black")>  _
        Public Property labelcolor() As Global.System.Drawing.Color
            Get
                Return CType(Me("labelcolor"),Global.System.Drawing.Color)
            End Get
            Set
                Me("labelcolor") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Microsoft Sans Serif, 8.25pt")>  _
        Public Property labelfont() As Global.System.Drawing.Font
            Get
                Return CType(Me("labelfont"),Global.System.Drawing.Font)
            End Get
            Set
                Me("labelfont") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("128, 128, 255")>  _
        Public Property gridbackcolor() As Global.System.Drawing.Color
            Get
                Return CType(Me("gridbackcolor"),Global.System.Drawing.Color)
            End Get
            Set
                Me("gridbackcolor") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("White")>  _
        Public Property gridforecolor() As Global.System.Drawing.Color
            Get
                Return CType(Me("gridforecolor"),Global.System.Drawing.Color)
            End Get
            Set
                Me("gridforecolor") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Control")>  _
        Public Property tranbkcolor() As Global.System.Drawing.Color
            Get
                Return CType(Me("tranbkcolor"),Global.System.Drawing.Color)
            End Get
            Set
                Me("tranbkcolor") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Black")>  _
        Public Property tranfocolor() As Global.System.Drawing.Color
            Get
                Return CType(Me("tranfocolor"),Global.System.Drawing.Color)
            End Get
            Set
                Me("tranfocolor") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Times New Roman, 9.75pt, style=Bold")>  _
        Public Property tranfont() As Global.System.Drawing.Font
            Get
                Return CType(Me("tranfont"),Global.System.Drawing.Font)
            End Get
            Set
                Me("tranfont") = value
            End Set
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\bin\Debug\1NewDb.mdf;In"& _ 
            "tegrated Security=True;Connect Timeout=30;User Instance=True")>  _
        Public ReadOnly Property _1NewDbConnectionString() As String
            Get
                Return CType(Me("_1NewDbConnectionString"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\admin\Desktop\bin\bin\Debug\1N"& _ 
            "ewDb.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True")>  _
        Public ReadOnly Property _1NewDbConnectionString1() As String
            Get
                Return CType(Me("_1NewDbConnectionString1"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\bin\Debug\4NewDb.mdf;In"& _ 
            "tegrated Security=True;Connect Timeout=30;User Instance=True")>  _
        Public ReadOnly Property _4NewDbConnectionString() As String
            Get
                Return CType(Me("_4NewDbConnectionString"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\bin\Debug\5NewDb.mdf;In"& _ 
            "tegrated Security=True;Connect Timeout=30;User Instance=True")>  _
        Public ReadOnly Property _5NewDbConnectionString() As String
            Get
                Return CType(Me("_5NewDbConnectionString"),String)
            End Get
        End Property
    End Class
End Namespace

Namespace My
    
    <Global.Microsoft.VisualBasic.HideModuleNameAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Module MySettingsProperty
        
        <Global.System.ComponentModel.Design.HelpKeywordAttribute("My.Settings")>  _
        Friend ReadOnly Property Settings() As Global.Tectile.My.MySettings
            Get
                Return Global.Tectile.My.MySettings.Default
            End Get
        End Property
    End Module
End Namespace
