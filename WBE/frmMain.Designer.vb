<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.btnCustomers = New System.Windows.Forms.Button()
        Me.btnOrderLevels = New System.Windows.Forms.Button()
        Me.btnEditOrders = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnCustomers
        '
        Me.btnCustomers.Location = New System.Drawing.Point(73, 43)
        Me.btnCustomers.Name = "btnCustomers"
        Me.btnCustomers.Size = New System.Drawing.Size(75, 31)
        Me.btnCustomers.TabIndex = 0
        Me.btnCustomers.Text = "Customers"
        Me.btnCustomers.UseVisualStyleBackColor = True
        '
        'btnOrderLevels
        '
        Me.btnOrderLevels.Location = New System.Drawing.Point(73, 104)
        Me.btnOrderLevels.Name = "btnOrderLevels"
        Me.btnOrderLevels.Size = New System.Drawing.Size(75, 31)
        Me.btnOrderLevels.TabIndex = 1
        Me.btnOrderLevels.Text = "Order Levels"
        Me.btnOrderLevels.UseVisualStyleBackColor = True
        '
        'btnEditOrders
        '
        Me.btnEditOrders.Location = New System.Drawing.Point(73, 167)
        Me.btnEditOrders.Name = "btnEditOrders"
        Me.btnEditOrders.Size = New System.Drawing.Size(75, 31)
        Me.btnEditOrders.TabIndex = 2
        Me.btnEditOrders.Text = "Edit Orders"
        Me.btnEditOrders.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(222, 252)
        Me.Controls.Add(Me.btnEditOrders)
        Me.Controls.Add(Me.btnOrderLevels)
        Me.Controls.Add(Me.btnCustomers)
        Me.Name = "frmMain"
        Me.Text = "WBE"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCustomers As System.Windows.Forms.Button
    Friend WithEvents btnOrderLevels As System.Windows.Forms.Button
    Friend WithEvents btnEditOrders As System.Windows.Forms.Button
End Class
