   M S B A M L   `   `   `  ����I  ECosmeticHealth, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:CosmeticHealth.AddPagesCosmeticHealth.AddPages  5      ,    &CosmeticHealth.AddPages.AddProductPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:CosmeticHealth.AddPages     5        N� Title$  AddProductPage��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $	��500 �6    � RowDefinitions 5   
   �� 5      �� 5      �� 5      .+�5   
   �� $��0��6   $��0��6   $��2��6-   $3��-Редактирование продукта��6A    
  Titles#��[  6c   �� 5   
   $��1��6   $��1��6!     	WinButton#��[ 6.   $��Center=�6l   $��Подтвердить��6�   ��6Q   �� *Accept+{�5      `� 5        	hasErrors `� 	Converter# [ 6   .1�5      ��  �� ElementName$ nameProduct��6    �� Path$ (Validation.HasError)�68   �� 5      $ descPro��6   $ (Validation.HasError)�64   �� 5      $ howPro��6   $ (Validation.HasError)�63   �� 5      $ imagePro��6   $ (Validation.HasError)�65   �� 5      $ typeCB��6   $ (Validation.HasError)�63   �� 5      $ typeSkin��6   $ (Validation.HasError)�65   �� 5      $ brandCB��6   $ (Validation.HasError)�64   �� 5       $ 
irritantCB��6   $ (Validation.HasError)�67   5!      5#      �� 5$   
   $��1��6   $��2��6!   #��[ 6.   $��Center=�6j   ��6Q   �� *Back+.��6�   Отмена6�   �� 5%   
   $��1��6   $��0��6"   $��2��62   .+�5&      ��   	LoginPass#��[ 6   .��67   #!Название продукта6J   �� 5'      -   5         ��Name$ nameProduct��5'   C   $��30��6     LogPass#��[ 6"   ��6X   �� *Product.ProductName+ �� ValidatesOnDataErrors$
 True�� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5(      
���  ����6)   �� $ nameProduct��$) #(Validation.Errors)[0].ErrorContent��� 5)      #��[ 6   .��67   Описание6A   �� 5*      -   5        $ descPro��5*   C   $��30��6   #��[ 6"   ��6T   �� *Product.Description+$
 True��$ PropertyChanged=�6�   �� 5+      
���  ����6)   �� $ descPro��$) #(Validation.Errors)[0].ErrorContent��� 5,      #��[ 6   .��67   #!Способ применения6J   �� 5-      -   5        $ howPro��5-   C   $��30��6   #��[ 6"   ��6S   �� *Product.HowUse+$
 True��$ PropertyChanged=�6�   �� 5.      
���  ����6)   �� $ howPro��$) #(Validation.Errors)[0].ErrorContent��� 5/      #��[ 6   .��67   Изображение6D   �� 50      -   5        $ imagePro��50   C   $��30��6   #��[ 6"   ��6U   �� *Product.Image+$
 True��$ PropertyChanged=�6�   �� 51      
���  ����6)   �� $ imagePro��$) #(Validation.Errors)[0].ErrorContent��� 52      #��[ 6   .��67   Вид продукта6E   �� 53      -   5        	 ��Name$	 typeCB��53   8     Filters#��[ 6   ��6H   �� *TypeOfProducts+
 �� SelectedItem
 6o   �� *Product.Type+$
 True����54      �� 55      .R�56      �� �� 57      �6"   �� *NameTypeOfProduct+58      59      5;      �� 5<      
���  ����6)   �� $ typeCB��$) #(Validation.Errors)[0].ErrorContent��� 5=      #��[ 6   .��67   Тип кожи6A   �� 5>      -   5        $	 typeSkin��5>   8   #��[ 6   ��6J   �� *TypeOfSkins+
 6n   �� *Product.TypeOfSkin+$
 True����5?      �� 5@      .R�5A      �� �� 5B      �6"   �� *TypeOfSkinName+5C      5D      5F      �� 5G      
���  ����6)   �� $ typeSkin��$) #(Validation.Errors)[0].ErrorContent��� 5H      #��[ 6   .��67   
Бренд6>   �� 5I      -   5        $	 brandCB��5I   8   #��[ 6   ��6I   �� *Brands+
 6h   �� *Product.Brand+$
 True����5J      �� 5K      .R�5L      �� �� 5M      �6"   �� *	NameBrand+5N      5O      5Q      �� 5R      
���  ����6)   �� $ brandCB��$) #(Validation.Errors)[0].ErrorContent��� 5S      #��[ 6   .��67   Раздражители6E   �� 5T      -   5        $	 
irritantCB��5T   8   #��[ 6   ��6L   �� *	Irritants+
 6n   �� *Product.Irritant+$
 True����5U      �� 5V      .R�5W      �� �� 5X      �6"   �� *IrritantName+5Y      5Z      5\      �� 5]      
���  ����6)   �� $ 
irritantCB��$) #(Validation.Errors)[0].ErrorContent�5^      5_      5`      