   M S B A M L   `   `   `  ����L  HMotorbikeStockApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:MotorbikeStockAppMotorbikeStockApp  5   	   "    MotorbikeStockApp.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:MotorbikeStockApp     5   	     � Title$  Motorcycle Stock��5   	   $	��450��6"   $	��800��6/   
�����F�.��5	      � .+�5
   
   �� $��Motorcycle manufacturer:��6   $
��Left=�63   $��	10,10,0,0q�6N   $	��Top=�6a   $��SemiBold"�6y   �� 5   
   -   5        $��listManufacturers��5      $
��Left=�6,   $��170, 15, 0, 0q�6G   $	��200��6^   $��20��6j   $	��Top=�6v   6�   �� 5   
   -   5        $��Add New Motorcycle��5      $
��Left=�6.   $��600, 15, 0, 0 q�6I   $	��150��6a   $��20��6m   $	��Top=�6y   6�   �� 5   
   -   5        $��See Previous Owner��5      $
��Left=�6.   $��10, 365, 0, 0q�6I   $	��150��6`   $��20��6l   $	��Top=�6x   6�   �� 5   
   -   5        $��Edit Selected Item��5      $
��Left=�6.   $��170, 365, 0, 0q�6I   $	��150��6a   $��20��6m   $	��Top=�6y   6�   �� 5   
   -   5        $��Remove Selected Item��5      $
��Left=�60   $��600, 365, 0, 0q�6K   $	��150��6c   $��20��6o   $	��Top=�6{   6�   �� 5   
   -   5        $��listMotorcycles��5      $
��Left=�6*   $��10, 50, 0, 0q�6E   $	��740��6[   $	��300��6g   $	��Top=�6t   
������� �� View 5      �� 5      .P�5      �� $��Registration��6%    �� Width$ 90��6;    �� DisplayMemberBinding 6G   �� *VehicleRegistration+�� 5      $��Manufacturer��6%   $	 120��6;    6G   �� *Manufacturer+�� 5      $��Model��6%   $	 120��64    6@   �� *Model+�� 5      $��Millage��6%   $ 90��66    6A   �� *	Millage+�� 5      $��Date Obtained��6%   $	 100��6<    6H   �� *DatePurchased+ �� StringFormat$ {0:dd MMM yyyy}���� 5      $��Previous Owner��6%   $	 215��6=    6I   �� *PreviousOwner.FullName+5      5      5      5      