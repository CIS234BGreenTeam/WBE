Public Class BakedGood
    Implements IComparable(Of BakedGood)
    '* Class Name: BakedGood.vb. 
    '* Designer: Ken Baker 4/20/2013. 
    '* Purpose:  Contains properties and validations

    Private m_dUnitPrice As Decimal
    Private sName As String
    Private _dteInactiveDate As DateTime

    Public Property IsInactive() As Boolean
    Public Property DesiredQty() As Integer
    Public Property StockQty() As Integer
    Public Property BakedGoodID() As Integer
    Public Property DisplayAll() As Boolean

    Public Property Name() As String
        Get
            Return sName
        End Get
        Set(ByVal value As String)
            If value.Length >= 2 And value.Length <= 30 Then
                sName = value
            Else
                Throw New Exception("Name must contain between 2 and 30 characters")
            End If
        End Set
    End Property

    '''<summary>
    '''Cost of single baked good
    '''</summary>
    ''' <remarks>If invald, throws UnitPriceError()</remarks>
    Public Overridable Property UnitPrice() As Decimal
        Get
            Return m_dUnitPrice
        End Get
        Set(ByVal value As Decimal)
            If value >= 0.5D And value <= 250D Then
                m_dUnitPrice = value
            Else
                Throw New Exception(UnitPriceError)
            End If

        End Set
    End Property

    '''<summary>
    '''Returns error message if called by UnitPrice()
    '''</summary>
    Public ReadOnly Property UnitPriceError() As String
        Get
            Return "UnitPrice Price must be between $0.50 and $250.00. "
        End Get

    End Property

    Public Function GetOrderQty() As Integer
        Return DesiredQty - StockQty
    End Function

    ''' <summary>
    ''' Constructor with data
    ''' </summary>
    ''' <param name="objBakedGoodID">Identifier of baked good (needed to obtain Name)</param>
    ''' <param name="objName">The name of the baked good</param>
    ''' <param name="objUnitPrice">UnitPrice of the baked good</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal objBakedGoodID As Integer,
                   ByVal objName As String,
                   ByVal objUnitPrice As Decimal)
        BakedGoodID = objBakedGoodID
        Name = objName
        UnitPrice = objUnitPrice
    End Sub

    ''' <summary>
    ''' default constructor (no data)
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

    End Sub

    ''' <summary>
    ''' If the baked good is inactive,
    ''' the date that WBE stopped producing the Baked Good
    ''' </summary>
    Public Property InactiveDate() As DateTime
        Get
            Return _dteInactiveDate
        End Get
        Set(ByVal Value As DateTime)
            _dteInactiveDate = Value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Dim sDisplay As String
        Dim sStatus As String

        If IsInactive = True Then
            sStatus = "I"
        Else
            sStatus = "A"
        End If

        If DisplayAll = True Then
            sDisplay = String.Format("{0,-19} {1, 6:c} {2, 4}", Name, UnitPrice, sStatus)
        Else
            sDisplay = Name
        End If

        Return sDisplay
    End Function

    Public Function CompareTo(other As BakedGood) As Integer Implements IComparable(Of BakedGood).CompareTo
        Return Me.Name.CompareTo(other.Name)
    End Function
End Class
