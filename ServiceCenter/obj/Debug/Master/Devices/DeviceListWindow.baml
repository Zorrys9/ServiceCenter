   M S B A M L   `   `   `  ����H  DServiceCenter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:ServiceCenter.Master.DevicesServiceCenter.Master.Devices  5   	   3    -ServiceCenter.Master.Devices.DeviceListWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:ServiceCenter.Master.Devices     5   	     � Title$%  Список устройств��5   	   $��463.771��6"   $��807.5��63   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 
DeviceList��5
      $
��Left=�6'   $	��413��6B   $��	10,10,0,0q�6O   $	��Top=�6b   $	��539��6z   6�   �� 5   
   -   5         ��Name$
 Back��5      $��
Назад��6   $
��Left=�6/   $��70��6J   $��566,261,0,0q�6V   $	��Top=�6k   $	��216��6�   $��16(�6�   6�   �� 5   
   -   5        $ 	AddDevice��5      $<��6Добавить новое
     устройство��6$   $
��Left=�6V   $��80��6q   $��
566,10,0,0q�6}   $	��Top=�6�   $	��216��6�   $��16(�6�   6�   �� 5   
   $
��Left=�6   $��52��6/   $��
554,95,0,0q�6;   $
��Wrap=�6O   $����Для изменения или удаления устройства дважды щелкните по нужному устройству��6c   $	��Top=�6�   $	��228��6�   
���  �� �� TextAlignment$ Center=�6�   �� 5   
   $"��Фильтрация по : ��6   $
��Left=�6-   $	��104��6H   $��554,152,0,0q�6U   $	��Top=�6j   $	��228��6�   $��16(�6�   .��5      �� -   5         ��Name$ 
FilterItem��5      $
��Left=�6+   $��32��6F   $��0,0,-2,0q�6R   $	��Top=�6d   $	��218��6|   $��16(�6�   .@�5      �� $�� ��6   $
��Left=�6+   $	��216��6F   �� 5      $��Названию��6   $
��Left=�62   $	��216��6M   �� 5      $��Модели��6   $
��Left=�60   $	��216��6K   �� 5      $ ��Производителю��6   $
��Left=�67   $	��216��6R   5      5      �� 5   
   -   5         ��Name$ 
FilterName��5      $
��Left=�6&   $��31��6A   $��566,212,0,0q�6M    �� TextWrapping$
 Wrap=�6b   $�� ��6v   $	��Top=�6~   $	��202��6�   $��16(�6�   6�   �� 5   
   -   5        $ ExitAccount��5      $&�� Выход из аккаунта��6&   $
��Left=�6B   $��63��6]   $��566,350,0,0q�6i   $	��Top=�6~   $	��216��6�   $��16(�6�   6�   5      5      