   M S B A M L   `   `   `  ����I  ECosmeticHealth, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:CosmeticHealth.AddPagesCosmeticHealth.AddPages  5      /    )CosmeticHealth.AddPages.AddIngridientPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:CosmeticHealth.AddPages     5        N� Title$  AddIngridientPage��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $	��500 �6    � RowDefinitions 5   
   �� 5      �� 5      �� 5      .+�5   
   �� $��0��6   $��0��6   $��2��6-   $1��+Добавление ингредиента��6A    
  Titles#��[  6b   �� 5   
   $��1��6   $��1��6!     	WinButton#��[ 6.   $��Bottom=�6Q   $��Подтвердить��6l   ��6�   �� *Accept+{�5      `� 5        	hasErrors `� 	Converter# [ 6   .1�5      ��  �� ElementName$ nameIng��6    �� Path$ (Validation.HasError)�64   �� 5      $ descIng��6   $ (Validation.HasError)�64   �� 5      $ 
irritantCB��6   $ (Validation.HasError)�67   5      5      �� 5   
   $��1��6   $��2��6!   #��[ 6.   $��Center=�6Q   ��6l   �� *Back+.��6�   Отмена6�   �� 5    
   $��1��6   $��0��6"   $��2��62   .+�5!      ��   	LoginPass#��[ 6   .��67   )'Название ингредиента6M   �� 5"      -   5         ��Name$ nameIng��5"   7     LogPass#��[ 6   ��6H   �� *Ingredient.NameIngredient+ �� ValidatesOnDataErrors$
 True�� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5#      
���  ����6)   �� $ nameIng��$) #(Validation.Errors)[0].ErrorContent��� 5$      #��[ 6   .��67   Описание6A   �� 5%      -   5        $ descIng��5%   7   #��[ 6   ��6H   �� *Ingredient.Description+$
 True��$ PropertyChanged=�6�   �� 5&      
���  ����6)   �� $ descIng��$) #(Validation.Errors)[0].ErrorContent��� 5'      #��[ 6   .��67   Раздражители6E   �� 5(      -   5        	 ��Name$	 
irritantCB��5(   8     Filters#��[ 6   ��6L   �� *	Irritants+
 �� SelectedItem
 6n   �� *Ingredient.Irritant+$
 True����5)      �� 5*      .R�5+      �� �� 5,      �6"   �� *IrritantName+5-      5.      50      �� 51      
���  ����6)   �� $ 
irritantCB��$) #(Validation.Errors)[0].ErrorContent�52      53      54      