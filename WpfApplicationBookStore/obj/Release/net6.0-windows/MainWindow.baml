   M S B A M L   `   `   `  ���� R  NWpfApplicationBookStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:WpfApplicationBookStoreWpfApplicationBookStore  (    "WpfApplicationBookStore.MainWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     7local%clr-namespace:WpfApplicationBookStore       � Title$  
MainWindow��$	��700��$
��1200��.���  � ColumnDefinitions �� $
��auto ��� $��* �.+��� $��0��$��2q�
�������$	��250��$��Center=�$��2q�
�������._��� .+��� -   $��btnHome��$��20,30q�
����p��$��50��
�������$��20(�$��	ExtraBold"�.��Home�� -   $��btnEmployees��$��20,30q�
����p��$��50��
�������$��20(�$��	ExtraBold"�.��	Employees�� -   $��btnCustomers��$��20,30q�
����p��$��50��
�������$��20(�$��	ExtraBold"�.��	Customers�� -   $��btnProducts��$��20,30q�
����p��$��50��
�������$��20(�$��	ExtraBold"�.��
Products�� $��10,40q�$	��130��$	��130��$��Resources/logo.jpg���� -   $��	HomePanel��$��1��$��2q�$y�Visible=�
�������$��2q�
�������._��� $��Stretch=�.+��� $��48(�$��Heavy"�$��Center=�$��0,50,0,0q�
����p��.��Welcome to Book Education�� $
��0,10q�$��Resources/b6.jpg��$��Center=��� -   $��EmpolyeesPanel��$��1��$��2q�$y�	Collapsed=�
�������$��2q�
�������._��� $��Stretch=�
�������$��30q�.+�&   System.Windows.Controls.DataGrid  -   $��EmployeesGrid��$��5q�   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ *    MinColumnWidth$	 100Q�   CanUserAddRows$ False��   CanUserResizeColumns$
 True��� $��5q� � RowDefinitions �� $��* ��� $	��100 �.+�� $��0��$��5q�.+��� $��2q�$
��Bold"�.��Detailed Info:�� -   $��EmployeeLabel��$��2q�$	��---��]� $��1��$��5q�$
��Left=�.+��� -	   $��btnAddEmployee��$��5q�$��40��$��90��
�����f�$��10(�$
��Bold"�.��Add Employee�� -
   $��btnEditEmployee��$��5q�$��40��$��90��
����h{�$��10(�$
��Bold"�.��Edit Employee�� -   $��btnDeleteEmployee��$��5q�$��40��$��90��
������$��10(�$
��Bold"�.��Delete Employee�� -   $��CustomersPanel��$��1��$��2q�$y�	Collapsed=�
�������$��2q�
�������._��� $��Stretch=�
�������$��30q�.+�  -   $��CustomersGrid��$��5q�$ * $	 100Q�$ False��$
 True��� $��5q� �� $��* ��� $	��100 �.+�� $��0��$��5q�.+��� $��2q�$
��Bold"�.��Detailed Info:�� -   $��CustomerLabel��$��2q�$	��---��]� $��1��$��5q�$
��Left=�.+��� -   $��btnAddCustomer��$��5q�$��40��$��90��
�����f�$��10(�$
��Bold"�.��Add Customer�� -   $��btnEditCustomer��$��5q�$��40��$��90��
����h{�$��10(�$
��Bold"�.��Edit Customer�� -   $��btnDeleteCustomer��$��2q�$��40��$��90��
������$��10(�$
��Bold"�.��Delete Customer�� -   $��ProductsPanel��$��1��$��2q�$y�	Collapsed=�
�������$��2q�
�������._��� $��Stretch=�
�������$��30q�.+�  -   $��ProductGrid��$��5q�$ * $	 100Q�$ False��$
 True��� $��5q� �� $��* ��� $	��100 �.+�� $��0��$��5q�.+��� $��5q�$
��Bold"�.��Detailed Info:�� -   $��ProductLabel��$��5q�$	��---��]� $��1��$��5q�$
��Left=�.+��� -   $��btnAddProduct��$��5q�$��40��$��90��
�����f�$��10(�$
��Bold"�.��Add Product�� -   $��btnEditProduct��$��5q�$��40��$��90��
����h{�$��10(�$
��Bold"�.��Edit Product�� -   $��btnDeleteProduct��$��5q�$��40��$��90��
������$��10(�$
��Bold"�.��Delete Product