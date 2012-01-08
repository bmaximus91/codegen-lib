Imports System.Threading
Imports System.Security.Principal

Namespace Model
    '''
    '''<summary>
    ''' Class to fascilitate communication between UserInterace and Model Objects
    ''' An ModelContext exists for each Thread.<br/>
    '''<p>
    '''The class contains a Locale object, a UserObject currently running the application
    '''and a database connection.  It can also receive other attributes, by calling
    '''<code>setAttribute(String, Object)</code> and <code>getAttribute(String)</code></p>
    '''<b>IMPORTANT: The ModelContext must always be released in a finally clause</b>
    '''Typical Usage:
    ''' <example>
    '''<code lang="vbnet">
    '''		Try 
    '''	    	ModelContext.newCurrent(principal);
    '''			ModelContext.Current().setAttribute("something", someObject);
    '''     	...
    '''     	Object me = ModelContext.Current().getAttribute("something");
    '''     Finally
    '''     	ModelContext.release();
    '''     End Try
    '''</code>
    ''' </example>
    ''' </summary>
    ''' 
    Public Class ModelContext

        Private _locale As System.Globalization.CultureInfo = System.Globalization.CultureInfo.CurrentCulture
        Private _principal As ModelObjectPrincipal = Nothing
        Private _attributes As Hashtable = Nothing
        Private _dbUtils As DBUtils

        <ThreadStatic()> _
        Private Shared _current As ModelContext = Nothing

        Private Sub New(ByVal principal As ModelObjectPrincipal, _
                        ByVal locale As System.Globalization.CultureInfo)

            Me.new()
            ' private constructor...
            Me._principal = principal
            Me._locale = locale

        End Sub

        Private Sub New(ByVal principal As ModelObjectPrincipal)

            Me.New(principal, System.Globalization.CultureInfo.CurrentCulture())

        End Sub

        Private Sub New()
            Me._attributes = New Hashtable
            ' private constructor...
        End Sub

        '''    
        '''	 <summary>Creates a new intance of ModelContext and sets the Connection and Principal objects,
        '''	 and marks it as current. </summary>
        '''	 <param name="principal"> User object for Security checks </param>
        '''	 
        Public Shared Sub newCurrent(ByVal principal As ModelObjectPrincipal)
            setCurrent(New ModelContext(principal))
        End Sub

        '''    
        '''	 <summary>
        ''' Creates a new intance of ModelContext and sets the Connection,Principal and Lcoale objects,
        '''	and marks it as current. </summary>
        '''	<param name="principal"> User object for Security checks </param>
        '''	 
        Public Shared Sub newCurrent(ByVal principal As ModelObjectPrincipal, ByVal locale As System.Globalization.CultureInfo)
            setCurrent(New ModelContext(principal, locale))
        End Sub

        '''    
        '''	 <summary>
        ''' Creates a new intance of ModelContext and sets the Principal and Locale objects,
        '''	and marks it as current. 
        ''' <b>This method should only be used for testing</b>
        ''' </summary>
        '''	<param name="username"> User name of ModelObjectIdentity for Security checks </param>
        '''	 
        Public Shared Sub newCurrent(ByVal username As String, ByVal locale As System.Globalization.CultureInfo)
            Dim p As ModelObjectPrincipal = New ModelObjectPrincipal(username)
            setCurrent(New ModelContext(p, locale))
        End Sub

        '''    
        '''	<summary>
        ''' Creates a new intance of ModelContext and sets the Principal and Locale objects,
        '''	and marks it as current. <b>This method should only be used for testing</b>
        ''' </summary>
        Public Shared Sub newForUnitTests()
            Dim p As ModelObjectPrincipal = New ModelObjectPrincipal("Test")
            p.UserId = -1
            setCurrent(New ModelContext(p))
        End Sub

        '''    
        '''	<summary>
        ''' Creates a new intance of ModelContext and marks it as current. </summary>
        '''	 
        Public Shared Sub newCurrent()
            setCurrent(New ModelContext())
        End Sub

        Public Shared Sub release()
            setCurrent(Nothing)
        End Sub

        '''    
        '''	 <summary>Creates a new intance of ModelContext and marks it as current. </summary>
        '''	 
        Private Shared Sub setCurrent(ByVal uao As ModelContext)
            _current = uao
        End Sub

        '''    
        '''	 <summary>Retrieves the current intance of ModelContext </summary>
        '''
        Public Shared Function Current() As ModelContext

            If _current Is Nothing Then
                newCurrent()
            End If
            Return _current

        End Function

        Public Shared Property Locale() As System.Globalization.CultureInfo
            Get
                Return Current._locale
            End Get
            Set(ByVal value As System.Globalization.CultureInfo)
                Current._locale = value
            End Set
        End Property

        Public Shared Property CurrentUser() As ModelObjectPrincipal
            Get
                Return Current._principal
            End Get
            Set(ByVal value As ModelObjectPrincipal)
                Current._principal = value
            End Set
        End Property

        Public Shared Property CurrentDBUtils() As DBUtils
            Get
                If Current._dbUtils Is Nothing Then
                    Current._dbUtils = DBUtils.Current
                End If
                Return Current._dbUtils
            End Get
            Set(ByVal value As DBUtils)
                Current._dbUtils = value
            End Set
        End Property


        Private Shared Function getAttributes() As Hashtable
            If Current._attributes Is Nothing Then
                Current._attributes = New Hashtable(10)
            End If
            Return Current._attributes
        End Function

        Public Shared Sub setAttribute(ByVal key As String, ByVal val As Object)
            getAttributes().Add(key, val)
        End Sub

        Public Shared Function getAttribute(ByVal key As String) As Object
            Return getAttributes().Item(key)
        End Function


        Public Shared Sub beginTrans()
            If Current() Is Nothing Then
                Return
            End If

            If CurrentDBUtils Is Nothing Then
                Throw New ApplicationException("Application service connection is null!")
            End If

            CurrentDBUtils.beginTrans()

        End Sub

        Public Shared Sub commitTrans()
            If Current() Is Nothing Then
                Return
            End If

            If CurrentDBUtils Is Nothing Then
                Throw New ApplicationException("Application service connection is null!")
            End If

            CurrentDBUtils.commitTrans()

        End Sub

        Public Shared Sub rollbackTrans()
            If Current() Is Nothing Then
                Return
            End If

            If CurrentDBUtils Is Nothing Then
                Throw New ApplicationException("Application service connection is null!")
            End If

            CurrentDBUtils.rollbackTrans()

        End Sub
    End Class

End Namespace