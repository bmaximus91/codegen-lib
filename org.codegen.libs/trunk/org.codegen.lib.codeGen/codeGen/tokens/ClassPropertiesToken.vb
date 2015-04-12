﻿Imports System.Collections.Generic
Imports System.Text
Imports org.codegen.lib.codeGen.FileComponents

Namespace Tokens
    Public Class IfaceNameToken
        Inherits ReplacementToken
        Sub New()
            Me.StringToReplace = "MODEL_CLASS_IFACE_NAME"
        End Sub
        Public Overrides Function getReplacementCode(ByVal t As IObjectToGenerate) As String

            Dim PropertyInterface As String = _
                DirectCast(t.FileGroup(ModelObjectFileComponent.KEY), DotNetClassFileComponent).ClassInterface
            Return PropertyInterface

        End Function
    End Class

    Public Class ModelObjectParentArrayToken
        Inherits ReplacementToken
        Sub New()
            Me.StringToReplace = "SETUP_PARENTS_ARRAY"
        End Sub
        Public Overrides Function getReplacementCode(ByVal t As dotnet.IObjectToGenerate) As String
            If ModelGenerator.Current.dotNetLanguage = ModelGenerator.enumLanguage.CSHARP Then
                Return getReplacementCodeCSharp(t)
            Else
                Return getReplacementCodeVB(t)
            End If
        End Function

        Public Function getReplacementCodeCSharp(ByVal t As dotnet.IObjectToGenerate) As String

            Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()

            If t.DbTable.Associations().Count() > 0 Then

                Dim vec As List(Of IAssociation) = t.DbTable.Associations()

                For Each association As IAssociation In vec
                    If association.isParent Then
                        sb.Append("if  (this." & association.getVariableName() & "Loaded) {" & vbCrLf)
                        sb.Append("ret.Add(this." & association.getVariableName() & ");" & vbCrLf)
                        sb.Append("}" & vbCrLf)

                    End If

                Next


            End If

            Return sb.ToString()

        End Function

        Public Function getReplacementCodeVB(ByVal t As dotnet.IObjectToGenerate) As String

            Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()

            If t.DbTable.Associations().Count() > 0 Then

                Dim vec As List(Of IAssociation) = t.DbTable.Associations()

                For Each association As IAssociation In vec
                    If association.isParent Then
                        sb.Append("if  Me._" & association.getVariableName() & "Loaded Then" & vbCrLf)
                        sb.Append("ret.Add(me." & association.getVariableName() & ")" & vbCrLf)
                        sb.Append("End If" & vbCrLf)

                    End If

                Next


            End If

            Return sb.ToString()

        End Function
    End Class

    Public Class ModelObjectChildArrayToken
        Inherits MultiLingualReplacementToken
        Sub New()
            Me.StringToReplace = "SETUP_CHILDREN_ARRAY"
        End Sub
        

        Public Overrides Function getReplacementCodeCSharp(ByVal t As dotnet.IObjectToGenerate) As String
            Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()

            If t.DbTable.Associations().Count() > 0 Then
                Dim vec As List(Of IAssociation) = t.DbTable.Associations()

                For Each association As IAssociation In vec
                    If Not association.isParent Then
                        If association.isCardinalityMany Then
                            Dim dtype As String = association.ChildDatatype
                            'sb.Append(vbTab & "ret.add(me." & association.getVariableName() & ")" & vbCrLf)
                            sb.Append(vbTab & "if  (this." & association.getVariableName() & "Loaded) { // check if loaded first!" & vbCrLf)
                            sb.Append(vbTab & vbTab & "List< ModelObject > lp = this._" & association.getVariableName() & ".ConvertAll(" & vbCrLf)
                            sb.Append(vbTab & vbTab & vbTab & vbTab & "new Converter< " & dtype & ", ModelObject>((" & vbCrLf)
                            sb.Append(vbTab & vbTab & vbTab & dtype & " pf )=> {")
                            sb.Append(vbTab & vbTab & vbTab & vbTab & "return (ModelObject)pf;}));" & vbCrLf)

                            sb.Append(vbTab & vbTab & "ret.AddRange(lp);" & vbCrLf)
                            sb.Append(vbTab & "}" & vbCrLf)
                        Else
                            sb.Append(vbTab & "if  (this." & association.getVariableName() & "Loaded) {" & vbCrLf)
                            sb.Append(vbTab & vbTab & "ret.Add(this." & association.getVariableName() & ");" & vbCrLf)
                            sb.Append(vbTab & "}" & vbCrLf)
                        End If

                    End If

                Next
            End If

            Return sb.ToString()
        End Function
        Public Overrides Function getReplacementCodeVB(ByVal t As dotnet.IObjectToGenerate) As String
            Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()

            If t.DbTable.Associations().Count() > 0 Then
                Dim vec As List(Of IAssociation) = t.DbTable.Associations()

                For Each association As IAssociation In vec
                    If Not association.isParent Then
                        If association.isCardinalityMany Then
                            Dim dtype As String = association.ChildDatatype
                            'sb.Append(vbTab & "ret.add(me." & association.getVariableName() & ")" & vbCrLf)
                            sb.Append(vbTab & "if  Me._" & association.getVariableName() & "Loaded Then ' check if loaded first!" & vbCrLf)
                            sb.Append(vbTab & vbTab & "Dim lp As List(Of ModelObject) = Me._" & association.getVariableName() & ".ConvertAll( _" & vbCrLf)
                            sb.Append(vbTab & vbTab & vbTab & vbTab & "New Converter(Of " & dtype & ", ModelObject)(" & vbCrLf)
                            sb.Append(vbTab & vbTab & vbTab & "Function(pf As " & dtype & ")" & vbCrLf)
                            sb.Append(vbTab & vbTab & vbTab & vbTab & "Return DirectCast(pf, ModelObject)" & vbCrLf)
                            sb.Append(vbTab & vbTab & vbTab & "End Function))" & vbCrLf)
                            sb.Append(vbTab & vbTab & "ret.AddRange(lp)" & vbCrLf)
                            sb.Append(vbTab & "End If" & vbCrLf)
                        Else
                            sb.Append(vbTab & "if  Me._" & association.getVariableName() & "Loaded then" & vbCrLf)
                            sb.Append(vbTab & vbTab & "ret.Add(me." & association.getVariableName() & ")" & vbCrLf)
                            sb.Append(vbTab & "End If" & vbCrLf)
                        End If

                    End If

                Next
            End If

            Return sb.ToString()
        End Function
    End Class

    Public Class ClassAccessLevelToken
        Inherits ReplacementToken
        Sub New()
            Me.StringToReplace = "CLASS_ACCESS_LEVEL"
        End Sub

        Public Overrides Function getReplacementCode(ByVal t As IObjectToGenerate) As String
            Return "Public"
        End Function

    End Class

    Public Class GeneratedInterfaceToken
        Inherits ReplacementToken

        Sub New()
            Me.StringToReplace = "MODEL_INTERFACE_DEFINITION"
        End Sub

        Public Overrides Function getReplacementCode(ByVal t As IObjectToGenerate) As String

            Dim sb As StringBuilder = New StringBuilder()
            Dim PropertyInterface As String = _
                DirectCast(t.FileGroup(ModelObjectFileComponent.KEY), DotNetClassFileComponent).ClassInterface

            If String.IsNullOrEmpty(PropertyInterface) = False Then
                t.DbTable.addImplemetedInterface(PropertyInterface)

                sb.Append("#Region ""Interface""")
                sb.Append(vbCrLf)
                sb.Append("<System.Runtime.InteropServices.ComVisible(False)> _" & vbCrLf)
                sb.Append(vbTab & "Public Interface " & PropertyInterface & ":" & _
                                        " Inherits IModelObject")
                sb.Append(vbCrLf)

                Dim vec As Dictionary(Of String, IDBField) = t.DbTable.Fields()
                Dim proGen As IPropertyGenerator = ModelGenerator.Current.IPropertyGenerator

                For Each field As DBField In vec.Values

                    sb.Append(proGen.generateInterfaceDeclaration(field))


                Next

                For Each ass As IAssociation In t.DbTable.Associations
                    sb.Append(vbTab & ass.getInterfaceDeclaration)
                    sb.Append(vbCrLf)

                Next

                sb.Append("End Interface")
                sb.Append(vbCrLf)
                sb.Append("#End region ")
                sb.Append(vbCrLf)

            End If
            Return sb.ToString
        End Function


    End Class

    Public Class CSharpGeneratedInterfaceToken
        Inherits ReplacementToken

        Sub New()
            Me.StringToReplace = "MODEL_INTERFACE_DEFINITION"
        End Sub

        Public Overrides Function getReplacementCode(ByVal t As IObjectToGenerate) As String

            Dim sb As StringBuilder = New StringBuilder()
            Dim PropertyInterface As String = _
                DirectCast(t.FileGroup(ModelObjectFileComponent.KEY), DotNetClassFileComponent).ClassInterface

            If String.IsNullOrEmpty(PropertyInterface) = False Then
                t.DbTable.addImplemetedInterface(PropertyInterface)

                sb.Append("#region ""Interface""")
                sb.Append(vbCrLf)
                sb.Append("[System.Runtime.InteropServices.ComVisible(false)] " & vbCrLf)
                sb.Append(vbTab & "public interface " & PropertyInterface & ":" & _
                                        " IModelObject {")
                sb.Append(vbCrLf)

                Dim vec As Dictionary(Of String, IDBField) = t.DbTable.Fields()
                Dim proGen As IPropertyGenerator = ModelGenerator.Current.IPropertyGenerator

                For Each field As DBField In vec.Values
                    sb.Append(proGen.generateInterfaceDeclaration(field))
                Next

                For Each ass As IAssociation In t.DbTable.Associations
                    sb.Append(vbTab & ass.getInterfaceDeclaration)
                    sb.Append(vbCrLf)

                Next

                sb.Append("}")
                sb.Append(vbCrLf)
                sb.Append("#endregion")
                sb.Append(vbCrLf)

            End If
            Return sb.ToString
        End Function


    End Class
    Public Class RequiredFieldValidatorToken
        Inherits MultiLingualReplacementToken

        Sub New()
            Me.StringToReplace = "REQ_FIELDS_VALIDATOR"
        End Sub
        Public Overrides Function getReplacementCodeCSharp(t As dotnet.IObjectToGenerate) As String

            Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()
            Dim vec As Dictionary(Of String, IDBField) = t.DbTable.Fields()
            Dim cnt As Integer = 0

            For i As Integer = 0 To vec.Keys.Count - 1
                'Dim field As DBField = CType(vec(i), DBField)
                Dim field As IDBField = vec.Item(vec.Keys(i))

                If field.IsTableField() AndAlso Not field.isPrimaryKey AndAlso field.Nullable = False Then
                    If field.isNullableDataType Then

                        'If sb.Length > 0 Then sb.Append(" _").Append(vbCrLf & vbTab & vbTab).Append(" orElse ")
                        sb.Append("if (mo.").Append(field.RuntimeFieldName).Append(" == null ) {")

                    Else
                        'If sb.Length > 0 Then sb.Append(" _").Append(vbCrLf & vbTab & vbTab).Append(" orElse ")
                        sb.Append("if (string.IsNullOrEmpty( mo.").Append(field.RuntimeFieldName).Append(")) {")

                    End If
                    sb.Append(vbCrLf)
                    sb.Append(vbTab & vbTab)
                    sb.Append("throw new ModelObjectRequiredFieldException("""). _
                                Append(field.RuntimeFieldName).Append(""");"). _
                                Append(vbCrLf)
                    sb.Append("}").Append(vbCrLf)
                End If

            Next

            Return sb.ToString()
        End Function


        Public Overrides Function getReplacementCodeVb(ByVal t As IObjectToGenerate) As String

            Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()
            Dim vec As Dictionary(Of String, IDBField) = t.DbTable.Fields()
            Dim cnt As Integer = 0

            For i As Integer = 0 To vec.Keys.Count - 1
                'Dim field As DBField = CType(vec(i), DBField)
                Dim field As IDBField = vec.Item(vec.Keys(i))

                If field.IsTableField() AndAlso Not field.isPrimaryKey AndAlso field.Nullable = False Then
                    If field.isNullableDataType Then

                        'If sb.Length > 0 Then sb.Append(" _").Append(vbCrLf & vbTab & vbTab).Append(" orElse ")
                        sb.Append("if mo.").Append(field.RuntimeFieldName).Append(" is Nothing then")

                    Else
                        'If sb.Length > 0 Then sb.Append(" _").Append(vbCrLf & vbTab & vbTab).Append(" orElse ")
                        sb.Append("if String.isNullOrEmpty( mo.").Append(field.RuntimeFieldName).Append(") Then")

                    End If
                    sb.Append(vbCrLf)
                    sb.Append(vbTab & vbTab)
                    sb.Append("Throw new ModelObjectRequiredFieldException("""). _
                                Append(field.RuntimeFieldName).Append(""")"). _
                                Append(vbCrLf)
                    sb.Append("End if ").Append(vbCrLf)
                End If

            Next

            Return sb.ToString()
        End Function


    End Class

    Public Class FieldListToken
        Inherits ReplacementToken

        Sub New()
            Me.StringToReplace = "STRING_FIELD_LIST"
        End Sub

        Public Overrides Function getReplacementCode(ByVal t As IObjectToGenerate) As String

            Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()
            Dim vec As Dictionary(Of String, IDBField) = t.DbTable.Fields()

            For i As Integer = 0 To vec.Keys.Count - 1
                Dim field As DBField = CType(vec.Item(vec.Keys(i)), DBField)
                If i > 0 Then sb.Append(",")
                sb.Append(field.getConstantStr())

            Next

            Return sb.ToString()
        End Function


    End Class

    Public Class ClassFieldStringConstantsToken
        Inherits ReplacementToken

        Sub New()
            Me.StringToReplace = "STRCONSTANTS"
        End Sub

        Public Overrides Function getReplacementCode(ByVal t As IObjectToGenerate) As String

            If ModelGenerator.Current.dotNetLanguage = ModelGenerator.enumLanguage.CSHARP Then
                Return Me.getReplacementCodeCSharp(t)
            Else
                Return Me.getReplacementCodeVB(t)
            End If

        End Function

        Public Function getReplacementCodeCSharp(ByVal t As IObjectToGenerate) As String
            Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()
            Dim vec As Dictionary(Of String, IDBField) = t.DbTable.Fields()

            For Each field As DBField In vec.Values

                sb.Append(vbTab & vbTab & vbTab & "public const String " & field.getConstantStr() & " = """ & DBTable.getRuntimeName(field.FieldName()) & """;")
                sb.Append(vbCrLf)
            Next

            Return sb.ToString()
        End Function

        Public Function getReplacementCodeVB(ByVal t As IObjectToGenerate) As String
            Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()
            Dim vec As Dictionary(Of String, IDBField) = t.DbTable.Fields()

            For Each field As DBField In vec.Values

                sb.Append(vbTab & vbTab & vbTab & "public Const " & field.getConstantStr() & " as String = """ & DBTable.getRuntimeName(field.FieldName()) & """")
                sb.Append(vbCrLf)
            Next

            Return sb.ToString()
        End Function
    End Class

    Public Class ClassFieldIntConstantsToken
        Inherits ReplacementToken


        Sub New()
            Me.StringToReplace = "CONSTANTS"
        End Sub

        Public Overrides Function getReplacementCode(ByVal t As IObjectToGenerate) As String

            If ModelGenerator.Current.dotNetLanguage = ModelGenerator.enumLanguage.CSHARP Then
                Return Me.getReplacementCodeCSharp(t)
            Else
                Return Me.getReplacementCodeVB(t)
            End If

        End Function
        Public Function getReplacementCodeCSharp(ByVal t As IObjectToGenerate) As String
            Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()
            Dim vec As Dictionary(Of String, IDBField) = t.DbTable.Fields()

            Dim i As Integer = 0
            For Each field As DBField In vec.Values

                'If field.FieldName.ToUpper <> Me._dbTable.getPrimaryKeyName.ToUpper Then
                sb.Append(vbTab & vbTab & "public const int " & field.getConstant() & " = " & (i) & ";")
                i += 1
                sb.Append(vbCrLf)
                'End If

            Next
            ''keep primary key to be the last field 
            'sb.Append("    public Const " & Me._dbTable.getPrimaryKeyField.getConstant() & " as Integer = " & (i))
            Return sb.ToString()
        End Function
        Public Function getReplacementCodeVB(ByVal t As IObjectToGenerate) As String
            Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()
            Dim vec As Dictionary(Of String, IDBField) = t.DbTable.Fields()

            Dim i As Integer = 0
            For Each field As DBField In vec.Values

                'If field.FieldName.ToUpper <> Me._dbTable.getPrimaryKeyName.ToUpper Then
                sb.Append(vbTab & vbTab & "public Const " & field.getConstant() & " as Integer = " & (i))
                i += 1
                sb.Append(vbCrLf)
                'End If

            Next
            ''keep primary key to be the last field 
            'sb.Append("    public Const " & Me._dbTable.getPrimaryKeyField.getConstant() & " as Integer = " & (i))
            Return sb.ToString()
        End Function
    End Class

    Public Class ClassPropertiesToken
        Inherits ReplacementToken

        Sub New()
            Me.StringToReplace = "CLASS_PROPERTIES"
        End Sub

        Public Overrides Function getReplacementCode(ByVal t As IObjectToGenerate) As String

            If ModelGenerator.Current.dotNetLanguage = ModelGenerator.enumLanguage.CSHARP Then
                Return Me.getReplacementCodeCSharp(t)
            Else
                Return Me.getReplacementCodeVB(t)
            End If

        End Function


        Public Function getReplacementCodeCSharp(ByVal t As IObjectToGenerate) As String
            ' sJcode = sJcode.Replace("<>", getProperties())
            Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder(vbCrLf)
            Dim vec As Dictionary(Of String, IDBField) = t.DbTable.Fields()

            Dim i As Integer = 0
            For Each field As DBField In vec.Values
                'no need to generate anything for "id" field.  it is overriden
                If field.FieldName.ToLower.Equals("id") = False Then
                    'field.PropertiesImplementedInterface = Me.GenerateInterface
                    sb.Append(field.getProperty())
                End If

            Next

            sb.Append(Me.getAssociationProperties(CType(t.DbTable, DBTable)))

            Return sb.ToString()
        End Function

        Public Function getReplacementCodeVB(ByVal t As IObjectToGenerate) As String
            ' sJcode = sJcode.Replace("<>", getProperties())
            Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder(vbCrLf)
            Dim vec As Dictionary(Of String, IDBField) = t.DbTable.Fields()

            Dim i As Integer = 0
            For Each field As DBField In vec.Values
                'no need to generate anything for "id" field.  it is overriden
                If field.FieldName.ToLower.Equals("id") = False Then
                    'field.PropertiesImplementedInterface = Me.GenerateInterface
                    sb.Append(field.getProperty())
                End If

            Next

            sb.Append(Me.getAssociationProperties(CType(t.DbTable, DBTable)))

            Return sb.ToString()
        End Function

        Private Function getAssociationProperties(ByVal t As DBTable) As String
            Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()
            Dim vec As List(Of IAssociation)
            Dim commentSymbol As String = CStr(IIf(ModelGenerator.Current.dotNetLanguage = ModelGenerator.enumLanguage.VB, "'", "//"))
            If t.Associations().Count() > 0 Then
                sb.Append(vbCrLf & vbTab & vbTab & commentSymbol & " ASSOCIATIONS GETTERS/SETTERS BELOW!" & vbCrLf)
            End If

            vec = t.Associations()

            For Each association As IAssociation In vec
                sb.Append(association.getSetterGetter())
            Next

            Return sb.ToString()

        End Function

    End Class

    Public Class IdFieldImplementedInterfaceToken
        Inherits ReplacementToken

        Sub New()
            Me.StringToReplace = "ID_IMPLEMENTS"
        End Sub

        Public Overrides Function getReplacementCode(ByVal t As IObjectToGenerate) As String

            Dim PropertyInterface As String = _
                DirectCast(t.FileGroup(ModelObjectFileComponent.KEY), DotNetClassFileComponent).ClassInterface

            If String.IsNullOrEmpty(PropertyInterface) = False Then
                If t.DbTable.hasFieldName("id") Then
                    Return "Implements " & PropertyInterface & ".Id"
                Else
                    Return String.Empty
                End If
            Else
                Return String.Empty
            End If

        End Function
    End Class

End Namespace
