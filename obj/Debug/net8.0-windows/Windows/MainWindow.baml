   M S B A M L   `   `   `  ����E  AKsiegarnia, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:Ksiegarnia.MarkupExtensionsKsiegarnia.MarkupExtensions  5   	       Ksiegarnia.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   ;local)clr-namespace:Ksiegarnia.MarkupExtensions     5   	     � Title$  Strona główna��5   	   $
��1040��5   	   $	��850��5   	   $
��1100��6    � WindowState$ 	Maximized=�5   	    � WindowStartupLocation$ Manual=�5	   	   .��5      �� $
��Auto=�6   $
��Auto=�66   .��5   
   � -   5        $��MainGrid��5   $   $��0q�6    � Cursor$  ��6    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $��* �6    .+�5      �� -   5        $��TopBar��5   J   $��0��6   $	��Top=�6&   $��66��6>   ��5      �� 5       �� 
StartPoint$	 0,0&�6*    �� EndPoint$	 0,1&�6;   .��5      �  � Color$ 	#FF2C2C2C��6'    � Offset$ 0Q�69   � 5      $ 	#FF1F1F1F��6'   $ 1Q�69   5      .+�5"      � -   5        $��
TopBarGrid��5"   %   $
 Hand��6   	 � ColumnDefinitions	 5#      �� 5$      $��* �6+   �� 5%      $
��Auto �6+   .+�5(      �� -   5        $��
UserButton��5/      $��Witaj, Jan!��5(         UserButtonStyle#��[  5)      $
��Left=�5*      $��Center=�5+      $��20,0,0,0q�5,      $��0��5-      5/      �� 51      -   5        $��	CartPanel��51   t   
 �� Orientation$
 
Horizontal=�6!   $��Right=�6:   $��1��6V   $
 Hand��6f   .+�52      �� -   5         ��Name$ itemsInCartCounter��52   !     CartButtonStyle#��[ 53   !   $��0��54   !   $��55��55   !   $��61��56   !   $
 Hand��57   !   $��0,5,50,0q�58   !   59   !   5:      5;      5<      �� 5?      -   5        $��SearchPanel��5?   �   $��1��6   $��Center=�6&   $��Center=�6A   $��20,20,20,20q�6^   $	��300��6s   .+�5@      �� -   5        $��SearchLabel��5D      $��Wyszukaj książkę...��5@        PlaceholderTextStyle#��[ 5A      $
��Left=�5B      $��10,0,0,5q�5C      5D      �� 5F      -	   5        $��SearchBoxPanel��5F   S   $
 
Horizontal=�6   $��Center=�66   .+�5G      �� -
   5         ��Name$ 	SearchBox��5G        SearchBoxStyle#��[ 5H      $	��200��5J      $	��300��5K      �� 5L      -   5        $ findAllBooks��5L        CartActionButtonStyle#��[ 5M      $��Wyszukaj��5N      $��89��5O      $
��Bold"�5P      $��14(�5Q      5R      5S      5T      � 5W      -   5        $��AdGrid��5W       $��2��6   .+�5X      (� -   5        $��	AdViewbox��5X   Y    (� Stretch$ Uniform=�6   $	��250��6,   $��Center=�6<   .��5Y      �� -   5         ��Name$ AdvertisementImage��5Y      $
��None=�5[      ��5Z      =   7Ksiegarnia.MarkupExtensions.DynamicImageSourceExtension  *advertisement.png+5[      5\      �� 5^      -   5         ��Name$ 	BooksList��5^      $y�Hidden=�5_        BooksListViewStyle#��[ 5`      ��5b      �� 5c      .R�5d      � $��Center=�6(   5e      ��5g      �� 5h      .R�5i      ��   BookItemStyle#��[ 6%   ._�5j   "   �� $��Center=�6-   .+�5k   &   ��   BookTitleStyle#��[ 6G   ��60   �� *Title+6G   �� 5l   &   $	��150��6I   $	��200��6U   $��Uniform=�6b   $��5q�6t   ��6,   �� *	CoverPath+6t   �� 5m   &     AuthorTextStyle#��[ 6P   ��60   �� *AuthorFullName+6P   �� 5o   &   $��5q�60   $��14(�5p   '   $
��Bold"�5q   '   ���#555555 �� TextAlignment$ Center=�5s   '   �� 5t   '   $�	Ilość: ��6+    �� 5u   '   �6+   �� *Count+5v   '   5w   #   5x      5y      5{      5|      � 5      -   5        $��	BooksGrid��5   ,   $��3��6   $��10q�6     5�      �� 5�      $
��Auto �6$   �� 5�      $��* �6$   .+�5�      �� -   5        $��BooksHeader��5�      $��Zobacz wybrane produkty��5�       	 HeaderTextStyle#��[	 5�      $��0��5�      5�      �� 5�      -   5        $ RandomBooks��5�      $��1��5�      #��[ 5�      ��5�      �� 5�      .R�5�      � $��Center=�6(   5�      ��5�      �� 5�      .R�5�      �� #��[ 6%   ._�5�   "   �� $��Center=�6-   .+�5�   &   �� #��[ 6G   ��60   �� *Title+6G   �� 5�   &   $	��150��6I   $	��200��6U   $��Uniform=�6b   $��5q�6t   ��6,   �� *	CoverPath+6t   �� 5�   &   #��[ 6Q   ��60   �� *Author.FullName+6Q   5�   #   5�      5�      5�      5�      5�      5�      5�      