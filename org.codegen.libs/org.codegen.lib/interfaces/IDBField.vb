Imports Microsoft.VisualBasic

Public Class FieldLookupInfo
    Public DataSource As String
    Public ValueMember As String
    Public DisplayMember As String
End Class

Public Interface IDBField

    Function isEnumFromInt() As Boolean

    Function isBooleanFromInt() As Boolean

    ReadOnly Property FieldDataType() As String

    Function isBoolean() As Boolean
    Function isInteger() As Boolean
    Function isString() As Boolean
    Function isDate() As Boolean
    Function isDecimal() As Boolean
    Function isLookup() As Boolean
    Function isBinaryField() As Boolean

    Property AccessLevel() As String

    ''' <summary>
    ''' The runtime type as it was read from the database meta data.
    ''' </summary>
    Property OriginalRuntimeType() As System.Type

    Function isAuditField() As Boolean
    Property isPrimaryKey() As Boolean
    Function getConstant() As String
    Function getConstantStr() As String

    Function getClassVariableDeclaration(Optional ByVal accessLevel As String = "private", Optional ByVal withInitialiser As Boolean = True) As String
    Function getFieldDataType() As String

    ''' <summary>
    ''' Returns true if the generated property of the POCO is of a .net Nullable data type
    ''' </summary>
    ReadOnly Property isNullableProperty() As Boolean

    ''' <summary>
    ''' Returns true if field in database can be null
    ''' </summary>
    Property isDBFieldNullable() As Boolean

    Function getPropertyDataType() As String
    Function getProperty() As String
    Function getSQLParameter() As String

    Property ParentTable() As IDBTable

    ReadOnly Property PropertyName() As String
    ''' <summary>
    ''' The name of the field at 'runtime' ie, VB or C# name
    ''' </summary>
    ReadOnly Property RuntimeFieldName() As String

    ''' <summary>
    ''' If select statement uses a view to load object and that view 
    ''' brings fields from other tables, this returns true if 
    ''' the field is part of the table's fields collection
    ''' </summary>
    Property IsTableField() As Boolean

    ''' <summary>
    ''' The name of the field, as it in the database
    ''' </summary>
    Property FieldName() As String

    ''' <summary>
    ''' The System.Type of the field in C# / VB generated object
    ''' </summary>
    Property RuntimeType() As System.Type

    ''' <summary>
    ''' The System.Type as string of the field in C# / VB generated object
    ''' </summary>
    Property RuntimeTypeStr() As System.String

    Property Size() As Integer

    Property Precision() As Integer

    Property Scale() As Integer

    Property DBType() As String

    Property XMLSerializationIgnore() As Boolean

    ''' <summary>
    ''' If Me.RuntimeType Is not the same as Me.RuntimeType, 
    ''' it returns the appropriate Convert.toXXX call
    ''' </summary>
    Function getDataReaderConverter() As String


End Interface
