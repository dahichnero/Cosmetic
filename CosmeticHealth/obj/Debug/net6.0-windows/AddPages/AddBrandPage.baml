   M S B A M L   `   `   `  ����I  ECosmeticHealth, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:CosmeticHealth.AddPagesCosmeticHealth.AddPages  5      *    $CosmeticHealth.AddPages.AddBrandPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:CosmeticHealth.AddPages     5        N� Title$  AddBrandPage��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $	��500 �6    � RowDefinitions 5   
   �� 5      �� 5      �� 5      .+�5   
   �� $��0��6   $��0��6   $��2��6-   $'��!Добавление бренда��6A    
  Titles#��[  6]   �� 5   
   $��1��6   $��1��6!     	WinButton#��[ 6.   $��Bottom=�6Q   $��Подтвердить��6l   ��6�   �� *Accept+{�5      `� 5        	hasErrors `� 	Converter# [ 6   .1�5      ��  �� ElementName$ 	nameBrand��6    �� Path$ (Validation.HasError)�66   �� 5      $
 date��6   $ (Validation.HasError)�61   �� 5      $
 rate��6   $ (Validation.HasError)�61   5      5      �� 5   
   $��1��6   $��2��6!   #��[ 6.   $��Center=�6Q   ��6l   �� *Back+.��6�   Отмена6�   �� 5    
   $��1��6   $��0��6"   $��2��62   .+�5!      ��   	LoginPass#��[ 6   .��67   Название бренда6H   �� 5"      -   5         ��Name$ 	nameBrand��5"   8     LogPass#��[ 6   ��6K   �� *Brand.NameBrand+ �� ValidatesOnDataErrors$
 True�� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5#      
���  ����6)   �� $ 	nameBrand��$) #(Validation.Errors)[0].ErrorContent��� 5$      #��[ 6   .��67   Дата основания6G   �� 5%      -   5        $
 date��5%   8   #��[ 6   ��6F   �� *Brand.DateFound+$
 True��$ PropertyChanged=�6�   �� 5&      
���  ����6)   �� $
 date��$) #(Validation.Errors)[0].ErrorContent��� 5'      #��[ 6   .��67   Рейтинг6@   �� 5(      -   5        $
 rate��5(   8   #��[ 6   ��6F   �� *Brand.Rating+$
 True��$ PropertyChanged=�6�   �� 5)      
���  ����6)   �� $
 rate��$) #(Validation.Errors)[0].ErrorContent�5*      5+      5,      