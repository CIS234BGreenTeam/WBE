Public Class BakedGood
    Implements IComparable(Of BakedGood)
    '* Class Name: BakedGood.vb. 
    '* Designer: Ken Baker 4/20/2013. 
    '* Purpose:  Contains properties and validations
    '
    '* Updated: May 28, 2013 by Kristina Frye
    '* Added validation for Desired/Stock Qty fields
    '* Changed hard coded validation values and error messages to defined constants

    Private m_dUnitPrice As Decimal
    Private sName As String

    Public Property IsInactive() As Boolean
    Public Property BakedGoodID() As Integer
    Public Property DisplayAll() As Boolean

    Private c_MinName = 2
    Private c_MaxName = 30

    Public Property Name() As String
        Get
            Return sName
        End Get
        Set(ByVal value As String)
            If value.Length >= c_MinName And value.Length <= c_MaxName Then
                sName = value
            Else
                Throw New Exception(NameError)
            End If
        End Set
    End Property

    Private _NameError As String = String.Format("Name must contain between {0} and {1} characters", c_MinName, c_MaxName)

    Public ReadOnly Property NameError As String
        Get
            Return _NameError
        End Get
    End Property

    Private c_MinPrice = 0.5D
    Private c_MaxPrice = 250D

    '''<summary>
    '''Cost of single baked good
    '''</summary>
    ''' <remarks>If invalid, throws UnitPriceError()</remarks>
    Public Overridable Property UnitPrice() As Decimal
        Get
            Return m_dUnitPrice
        End Get
        Set(ByVal value As Decimal)
            If value >= c_MinPrice And value <= c_MaxPrice Then
                m_dUnitPrice = value
            Else
                Throw New Exception(UnitPriceError)
            End If

        End Set
    End Property
    Private _PriceError As String = String.Format("Price must be between {0:c} and {1:c}.", c_MinPrice, c_MaxPrice)
    '''<summary>
    '''Returns error message if called by UnitPrice()
    '''</summary>
    Public ReadOnly Property UnitPriceError() As String
        Get
            Return _PriceError
        End Get

    End Property
    Const c_MinDesiredQty = 0
    Const c_MaxDesiredQty = 300

    Private _iDesiredQty As Integer

    ''' <summary>
    ''' Quantity of baked good the customer desires to keep in their inventory
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DesiredQty As Integer
        Get
            Return _iDesiredQty
        End Get
        Set(value As Integer)
            If (value < c_MinDesiredQty Or value > c_MaxDesiredQty) Then
                Throw New Exception(DesiredQtyError)
            Else
                _iDesiredQty = value
            End If
        End Set
    End Property

    'Although the actual minimum quantity is zero, I'm adding 1 for the error message seen by users.
    Private _DesiredQtyError As String = String.Format("Desired quantity must be between {0} and {1}.",
                                                 c_MinDesiredQty + 1, c_MaxDesiredQty)

    ''' <summary>
    ''' Error message for desired quantity
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property DesiredQtyError As String
        Get
            Return _DesiredQtyError
        End Get
    End Property

    Const c_MinStockQty = 0
    Const c_MaxStockQty = 300

    Private _iStockQty As Integer

    ''' <summary>
    ''' Quantity of actual stock on hand counted by driver.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property StockQty As Integer
        Get
            Return _iStockQty
        End Get
        Set(value As Integer)
            If (value < c_MinStockQty Or value > c_MaxStockQty) Then
                Throw New Exception(StockQtyError)
            Else
                _iStockQty = value
            End If
        End Set
    End Property

    Private _StockQtyError As String = String.Format("Stock quantity must be between {0} and {1}.",
                                                 c_MinStockQty, c_MaxStockQty)

    ''' <summary>
    ''' Error message for stock quantity
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property StockQtyError As String
        Get
            Return _StockQtyError
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
