<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOrder
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboCustomer = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtDate = New System.Windows.Forms.DateTimePicker()
        Me.lstOrderItems = New System.Windows.Forms.ListBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblOrderNumber = New System.Windows.Forms.Label()
        Me.grpOrderItem = New System.Windows.Forms.GroupBox()
        Me.cboItem = New System.Windows.Forms.ComboBox()
        Me.txtPrice = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtQuantity = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.epOrder = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.btnDeleteItem = New System.Windows.Forms.Button()
        Me.btnDeleteOrder = New System.Windows.Forms.Button()
        Me.grpOrderItem.SuspendLayout()
        CType(Me.epOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Selection"
        '
        'cboCustomer
        '
        Me.cboCustomer.FormattingEnabled = True
        Me.cboCustomer.Location = New System.Drawing.Point(76, 19)
        Me.cboCustomer.Name = "cboCustomer"
        Me.cboCustomer.Size = New System.Drawing.Size(170, 21)
        Me.cboCustomer.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(213, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Date:"
        '
        'dtDate
        '
        Me.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtDate.Location = New System.Drawing.Point(249, 50)
        Me.dtDate.Name = "dtDate"
        Me.dtDate.Size = New System.Drawing.Size(86, 20)
        Me.dtDate.TabIndex = 1
        '
        'lstOrderItems
        '
        Me.lstOrderItems.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstOrderItems.FormattingEnabled = True
        Me.lstOrderItems.ItemHeight = 14
        Me.lstOrderItems.Location = New System.Drawing.Point(22, 108)
        Me.lstOrderItems.Name = "lstOrderItems"
        Me.lstOrderItems.Size = New System.Drawing.Size(313, 88)
        Me.lstOrderItems.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Status:"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(73, 54)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(63, 13)
        Me.lblStatus.TabIndex = 6
        Me.lblStatus.Text = "OrderStatus"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(22, 89)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 14)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Item"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(152, 89)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 14)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Quantity"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(221, 89)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 14)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Price"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(269, 89)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 14)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Ext Price"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(257, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 13)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Order #"
        '
        'lblOrderNumber
        '
        Me.lblOrderNumber.AutoSize = True
        Me.lblOrderNumber.Location = New System.Drawing.Point(306, 22)
        Me.lblOrderNumber.Name = "lblOrderNumber"
        Me.lblOrderNumber.Size = New System.Drawing.Size(28, 13)
        Me.lblOrderNumber.TabIndex = 12
        Me.lblOrderNumber.Text = "###"
        '
        'grpOrderItem
        '
        Me.grpOrderItem.Controls.Add(Me.cboItem)
        Me.grpOrderItem.Controls.Add(Me.txtPrice)
        Me.grpOrderItem.Controls.Add(Me.Label11)
        Me.grpOrderItem.Controls.Add(Me.txtQuantity)
        Me.grpOrderItem.Controls.Add(Me.Label10)
        Me.grpOrderItem.Controls.Add(Me.Label9)
        Me.grpOrderItem.Location = New System.Drawing.Point(22, 215)
        Me.grpOrderItem.Name = "grpOrderItem"
        Me.grpOrderItem.Size = New System.Drawing.Size(309, 88)
        Me.grpOrderItem.TabIndex = 3
        Me.grpOrderItem.TabStop = False
        Me.grpOrderItem.Text = "Order Item"
        '
        'cboItem
        '
        Me.cboItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboItem.FormattingEnabled = True
        Me.cboItem.Location = New System.Drawing.Point(95, 20)
        Me.cboItem.Name = "cboItem"
        Me.cboItem.Size = New System.Drawing.Size(160, 21)
        Me.cboItem.TabIndex = 0
        '
        'txtPrice
        '
        Me.txtPrice.Location = New System.Drawing.Point(192, 49)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(63, 20)
        Me.txtPrice.TabIndex = 2
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(155, 53)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(31, 13)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "Price"
        '
        'txtQuantity
        '
        Me.txtQuantity.Location = New System.Drawing.Point(94, 49)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(45, 20)
        Me.txtQuantity.TabIndex = 1
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(42, 53)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 13)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Quantity"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(61, 25)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(27, 13)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Item"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(354, 108)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(82, 30)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(354, 158)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(82, 30)
        Me.btnAdd.TabIndex = 5
        Me.btnAdd.Text = "&Add Item"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'epOrder
        '
        Me.epOrder.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.epOrder.ContainerControl = Me
        '
        'btnDeleteItem
        '
        Me.btnDeleteItem.Location = New System.Drawing.Point(354, 208)
        Me.btnDeleteItem.Name = "btnDeleteItem"
        Me.btnDeleteItem.Size = New System.Drawing.Size(82, 30)
        Me.btnDeleteItem.TabIndex = 6
        Me.btnDeleteItem.Text = "&Delete Item"
        Me.btnDeleteItem.UseVisualStyleBackColor = True
        '
        'btnDeleteOrder
        '
        Me.btnDeleteOrder.Location = New System.Drawing.Point(354, 258)
        Me.btnDeleteOrder.Name = "btnDeleteOrder"
        Me.btnDeleteOrder.Size = New System.Drawing.Size(80, 30)
        Me.btnDeleteOrder.TabIndex = 7
        Me.btnDeleteOrder.Text = "Delete &Order"
        Me.btnDeleteOrder.UseVisualStyleBackColor = True
        '
        'frmOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(458, 335)
        Me.Controls.Add(Me.btnDeleteOrder)
        Me.Controls.Add(Me.btnDeleteItem)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.grpOrderItem)
        Me.Controls.Add(Me.lblOrderNumber)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lstOrderItems)
        Me.Controls.Add(Me.dtDate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboCustomer)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmOrder"
        Me.Text = "WBE Order Form"
        Me.grpOrderItem.ResumeLayout(False)
        Me.grpOrderItem.PerformLayout()
        CType(Me.epOrder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboCustomer As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lstOrderItems As System.Windows.Forms.ListBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblOrderNumber As System.Windows.Forms.Label
    Friend WithEvents grpOrderItem As System.Windows.Forms.GroupBox
    Friend WithEvents txtPrice As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtQuantity As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents cboItem As System.Windows.Forms.ComboBox
    Friend WithEvents epOrder As System.Windows.Forms.ErrorProvider
    Friend WithEvents btnDeleteOrder As System.Windows.Forms.Button
    Friend WithEvents btnDeleteItem As System.Windows.Forms.Button
End Class
