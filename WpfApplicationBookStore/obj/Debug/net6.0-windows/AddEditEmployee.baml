   M S B A M L   `   `   `  ����R  NWpfApplicationBookStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:WpfApplicationBookStoreWpfApplicationBookStore  5   	   -    'WpfApplicationBookStore.AddEditEmployee   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:WpfApplicationBookStore     5   	     � Title$  AddEditEmployee��5   	   $��24(�6!   $	��700��6/   $	��800��6<   
�������.��5	      � .+�5
   
   �� $��10q�6   .+�5      ]� $��10q�6   .+�5      �� $��10q�6   .��6$   First Name:61   �� 5      -   5        $��tbFirstName��5      $��Right=�6-   $	��500��6I   
�������$��2q�6j   5      ]� 5      $��10q�6   .+�5      �� $��10q�6   .��6$   
Last Name:60   �� 5      -   5        $��
tbLastName��5      $��Right=�6,   $	��500��6H   
�������$��2q�6i   5      ]� 5      $��10q�6   .+�5      �� $��10q�6   .��6$   Phone Number:63   �� 5      -   5        $��tbPhoneNumber��5      $��Right=�6/   $	��500��6K   
�������$��2q�6l   /- // TextChanged="tbPhoneNumber_TextChanged"/>5      ]� 5      $��10q�6   .+�5      �� $��10q�6   .��6$   
Address:6.   �� 5      -   5        $��	tbAddress��5      $��Right=�6+   $	��500��6G   
�������$��2q�6h   5      ]� 5      $��10q�6   .+�5       �� $��10q�6   .��6$   Department:61   �� 5!      -   5        $��comboDepartment��5!      $��Right=�62   $	��500��6N   
�������$��2q�6o   .@�5"      �� .��6#   
Production6/   �� 5#      .��6#   Sales6*   �� 5$      .��6#   Advertisment61   �� 5%      .��6#   
Management6/   5&      5'      ]� 5)      $��10q�6   .+�5*      �� $��10q�6   .��6$   Base Salary:62   �� 5+      -   5        $��tbBaseSalary��5+      $��Right=�6.   $	��500��6J   
�������$��2q�6k   5,      �� 5.      -   5        $��lblError��5.      
���  ��$��18(�65   $
��Bold"�6C   $��2q�6U   $��Right=�6`   ]� 5/      $��10q�6   $��Right=�6$   .+�50      �� -   5        $��btnSave��50      $��50��6>   $	��120��6J   $��10q�6V   
�����f�
�������$��2q�6�   .��6�   Save6�   �� 51      -	   5        $��	btnCancel��51      $��50��6B   $	��120��6N   
������
�������$��2q�6�   .��6�   Cancel6�   52      53      54      55      