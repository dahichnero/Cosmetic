   M S B A M L   `   `   `  ����I  ECosmeticHealth, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:CosmeticHealth.AddPagesCosmeticHealth.AddPages  5      2    ,CosmeticHealth.AddPages.AddProblemTypeOfSkin   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:CosmeticHealth.AddPages     5        N� Title$  AddProblemTypeOfSkin��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $	��500 �6    � RowDefinitions 5   
   �� 5      �� 5      �� 5      .+�5   
   �� $��0��6   $��0��6   $��2��6-   $@��:Добавление Проблемы и Типа кожи��6A    
  Titles#��[  6k   �� 5   
   $��1��6   $��1��6!     	WinButton#��[ 6.   $��Center=�6Q   $��Подтвердить��6l   ��6�   �� *Accept+{�5      `� 5        	hasErrors `� 	Converter# [ 6   .1�5      ��  �� ElementName$
 prob��6    �� Path$ (Validation.HasError)�61   �� 5      $
 type��6   $ (Validation.HasError)�61   5      5      �� 5   
   $��1��6   $��2��6!   #��[ 6.   $��Center=�6Q   ��6l   �� *Back+.��6�   Отмена6�   �� 5   
   $��1��6   $��0��6"   $��2��62   .+�5!      ��   	LoginPass#��[ 6   .��67   Проблема6A   �� 5"      -   5         ��Name$
 prob��5"   8     Filters#��[ 6   ��6F   �� *
Problems+ �� SelectedItem 6g   �� *ProblemTypeOfSkin.Problem+ �� ValidatesOnDataErrors$
 True����5#      �� 5$      .R�5%      �� �� 5&      �6"   �� *ProblemName+5'      5(      5*      �� 5+      
���  ����6)   �� $
 prob��$) #(Validation.Errors)[0].ErrorContent��� 5,      #��[ 6   .��67   Тип кожи6A   �� 5-      -   5        $
 type��5-   8   #��[ 6   ��6F   �� *TypeOfSkins+ 6j   �� *ProblemTypeOfSkin.TypeOfSkin+$
 True����5.      �� 5/      .R�50      �� �� 51      �6"   �� *TypeOfSkinName+52      53      55      �� 56      
���  ����6)   �� $
 type��$) #(Validation.Errors)[0].ErrorContent�57      58      59      