   M S B A M L   `   `   `  ���� L  HMotorbikeStockApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:MotorbikeStockAppMotorbikeStockApp  +    %MotorbikeStockApp.AddMotorcycleWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     1localclr-namespace:MotorbikeStockApp       � Title$  Add A New Motorcycle��$	��350��$	��600��
�������.��� .+��� $��Add a new motorcycle��$��Center=�$��SemiBold"��� $��Vehicle Registration��$
��Left=�$	��Top=�$��
10, 30,0,0q�$��Light"��� -    ��Name$ 
vehicleReg��$	��150��$��20��$
��Left=�$	��Top=�$��	15,55,0,0q�
��������� $��Manufacturer��$
��Left=�$	��Top=�$��	10,80,0,0q�$��Light"��� -   $��vehicleManufacturer��$	��150��$��20��$
��Left=�$	��Top=�$��
15,105,0,0q�
��������� $��Model��$
��Left=�$	��Top=�$��10, 130,0,0q�$��Light"��� -   $ vehicleModel��$	��150��$��20��$
��Left=�$	��Top=�$��
15,155,0,0q�
��������� $��Millage��$
��Left=�$	��Top=�$��10, 180,0,0q�$��Light"��� -   $ vehicleMillage��$	��150��$��20��$
��Left=�$	��Top=�$��
15,205,0,0q�
��������� $��Date Purchased��$
��Left=�$	��Top=�$��10, 230,0,0q�$��Light"�(  "System.Windows.Controls.DatePicker  -     Name$ vehiclePurchaseDate��$	��150��$��26��$
��Left=�$	��Top=�$��
15,255,0,0q�
��������� $��Previous Owner Details��$
��Left=�$	��Top=�$��
330,30,0,0q��� $��
First Name��$
��Left=�$	��Top=�$��
330,55,0,0q�$��Light"��� -   $ 	firstName��$	��100��$��20��$
��Left=�$	��Top=�$��
335,80,0,0q�
��������� $��Surname��$
��Left=�$	��Top=�$��
440,55,0,0q�$��Light"��� -   $ surname��$	��135��$��20��$
��Left=�$	��Top=�$��
445,80,0,0q�
��������� $��Address��$
��Left=�$	��Top=�$��330,105,0,0q�$��Light"��� -   $ address1��$	��245��$��20��$
��Left=�$	��Top=�$��335,130,0,0q�
��������� -	   $ address2��$	��245��$��20��$
��Left=�$	��Top=�$��335,155,0,0q�
��������� -
   $ address3��$	��245��$��20��$
��Left=�$	��Top=�$��335,180,0,0q�
��������� -   $ address4��$	��245��$��20��$
��Left=�$	��Top=�$��335,205,0,0q�
��������� $��Postcode��$
��Left=�$	��Top=�$��330,230,0,0q�$��Light"��� -   $ postcode��$	��190��$��20��$
��Left=�$	��Top=�$��390,230,0,0q�
��������� $��Telephone No:��$
��Left=�$	��Top=�$��330,255,0,0q�$��Light"��� -   $ telephoneNo��$	��162��$��20��$
��Left=�$	��Top=�$��418,255,0,0q�
��������� -   $��Cancel��$��20��$	��100��$��245,280,0,0q��� -   $��Confirm��$��20��$	��100��$��465,280,0,0q�