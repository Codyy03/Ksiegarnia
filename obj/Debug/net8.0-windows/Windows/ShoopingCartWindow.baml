   M S B A M L   `   `   `  ����E  AKsiegarnia, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:Ksiegarnia.MarkupExtensionsKsiegarnia.MarkupExtensions  5   	   #    Ksiegarnia.ShoopingCartWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   ;local)clr-namespace:Ksiegarnia.MarkupExtensions     5   	   $
��1070��5   	     � Title$  Koszyk��5   	   $	��850��6   $
��1100��6%    � 	Resources 5      3  -System.Windows.Media.Effects.DropShadowEffect   DefaultDropShadowEffect   Color   
BlurRadius   ShadowDepth   Opacity��%R   &	          5	   
   $ Black��6;   $ 8Q�6I   $ 2Q�6X   $	 0.3Q�6h   5
      .��5      � $��10q�6    � ColumnDefinitions 5   
   �� 5      $��* �6   $	��400��6)   �� 5      $	��300 �6   $	��250��6+   .+�5   
   �� -   5         ��Name$ BooksInShoopingCart��5      $��0��5        CartListViewStyle#��[ 5      $��10q�5      $��Disabled=�5       %� IsVirtualizing$ False��5      ��5      �� 5      .R�5      � 	 � Orientation$	 
Horizontal=�6    
 K� IsItemsHost$

 True��5        � 	ItemWidth$	 200��5        � 
ItemHeight$
 Auto��5       5       ��5"      �� 5#      .R�5$      ��   CartItemStyle#��[ 6   $��5q�6D    J� Effect# [  6O   ._�5%      ��  �� Orientation$ Vertical=�6%   $��Center=�6<   .+�5'      �� $��20(�5(   (   $
��Bold"�5)   (    �� TextAlignment$ Center=�5*   (   $��0,0,0,8q�5+   (   $��CharacterEllipsis=�5,   (   ��5'   (   �� *Title+ � ToolTip 5-   (   �� *Title+�� 5/      $	��160��50   $   $	��220��60   $��Uniform=�51   $   $��0,0,0,8q�52   $   ��5/   $   �� *	CoverPath+52   $   �� 54      $��Italic$�55   (   $ Center=�56   (   $��0,0,0,8q�57   (   ��54   (   �� *Author.FullName+57   (   �� 59      $��20(�5:   (   
��� � �$ Center=�5<   (   $��0,0,0,8q�5=   (   ��59   (   �� *PriceWithZl+5=   (   �� 5>      -   5        $��Usuń��5>   %   $��0,8,0,0q�5?   %   ���#FF5722
�������$
��Bold"�5C   %    � Cursor$
 Hand��5D   %   $	��5,2q�5E   %   5F      5G      5H      5J      �� 5M   
   $��1��6    �� CornerRadius$ 10��5N      $��10q�5O       �� Padding$ 20q�5P      
����������#E0E0E0$��1q�5S      # [  5T      ._�5U      �� .+�5V      �� $��Podsumowanie zamówienia��6   $��18(�5W      $
��Bold"�5X      ���#333333$��Center=�5Z      $��0,0,0,15q�5[      �� 5\      $��0,0,0,10q�6   ���#CCCCCC$��1��6C   �� 5]      -   5         ��Name$ 
TotalPrice��5]      $��0��60   $��15(�5^      $
��Bold"�5_      
��� � �$��Center=�5a      $��0,0,0,10q�5b      �� 5c      -   5        $ delivery��5c      $��Dostawa od 10 zł��6.   $��16(�5d      $��Center=�5e      $��0,0,0,20q�5f      �� 5g      -   5         ��Name$ ShoppingSummary��5g      $��Podsumowanie��62     CartActionButtonStyle#��[ 5h      $��0,0,0,10q�5i      5j      �� 5k      -   5        $ BackToSearch��5k      $��Powrót��6/     AddToCartButtonStyle#��[ 5l      $��Center=�5m      $	��185��5n      $��5,100,10,10q�5p      5q      5r      5s      5t      