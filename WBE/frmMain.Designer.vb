﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.btnCount = New System.Windows.Forms.Button()
        Me.btnBakedGoods = New System.Windows.Forms.Button()
        Me.btnGenerateOrders = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnCustomers
        '
        Me.btnCustomers.Location = New System.Drawing.Point(40, 29)
        Me.btnCustomers.Name = "btnCustomers"
        Me.btnCustomers.Size = New System.Drawing.Size(75, 41)
        Me.btnCustomers.TabIndex = 0
        Me.btnCustomers.Text = "Customers"
        Me.btnCustomers.UseVisualStyleBackColor = True
        '
        'btnOrderLevels
        '
        Me.btnOrderLevels.Location = New System.Drawing.Point(159, 100)
        Me.btnOrderLevels.Name = "btnOrderLevels"
        Me.btnOrderLevels.Size = New System.Drawing.Size(75, 41)
        Me.btnOrderLevels.TabIndex = 3
        Me.btnOrderLevels.Text = "Order Levels"
        Me.btnOrderLevels.UseVisualStyleBackColor = True
        '
        'btnEditOrders
        '
        Me.btnEditOrders.Location = New System.Drawing.Point(40, 171)
        Me.btnEditOrders.Name = "btnEditOrders"
        Me.btnEditOrders.Size = New System.Drawing.Size(75, 41)
        Me.btnEditOrders.TabIndex = 4
        Me.btnEditOrders.Text = "Edit Orders"
        Me.btnEditOrders.UseVisualStyleBackColor = True
        '
        'btnCount
        '
        Me.btnCount.Location = New System.Drawing.Point(40, 100)
        Me.btnCount.Name = "btnCount"
        Me.btnCount.Size = New System.Drawing.Size(75, 41)
        Me.btnCount.TabIndex = 2
        Me.btnCount.Text = "Count Inventory"
        Me.btnCount.UseVisualStyleBackColor = True
        '
        'btnBakedGoods
        '
        Me.btnBakedGoods.Location = New System.Drawing.Point(159, 29)
        Me.btnBakedGoods.Name = "btnBakedGoods"
        Me.btnBakedGoods.Size = New System.Drawing.Size(75, 41)
        Me.btnBakedGoods.TabIndex = 1
        Me.btnBakedGoods.Text = "Baked Goods"
        Me.btnBakedGoods.UseVisualStyleBackColor = True
        '
        'btnGenerateOrders
        '
        Me.btnGenerateOrders.Location = New System.Drawing.Point(159, 171)
        Me.btnGenerateOrders.Name = "btnGenerateOrders"
        Me.btnGenerateOrders.Size = New System.Drawing.Size(75, 41)
        Me.btnGenerateOrders.TabIndex = 5
        Me.btnGenerateOrders.Text = "&Generate Orders"
        Me.btnGenerateOrders.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(270, 256)
        Me.Controls.Add(Me.btnGenerateOrders)
        Me.Controls.Add(Me.btnBakedGoods)
        Me.Controls.Add(Me.btnCount)
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
    Friend WithEvents btnCount As System.Windows.Forms.Button
    Friend WithEvents btnBakedGoods As System.Windows.Forms.Button
    Friend WithEvents btnGenerateOrders As System.Windows.Forms.Button
End Class
