   M S B A M L   `   `   `  ����  
Ksiegarnia"    Ksiegarnia.BookDetailsWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Aav2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6G     � Title$  Szczegóły książki��5   	   $	��850��6#   $
��1100��60   $
��1040��5   	    � WindowState$ 	Maximized=�5   	    � WindowStartupLocation$ Manual=�5   	   .��5
      �� $
��Auto=�6   $
��Auto=�66   .��5   
   � $
��1226��6    � RowDefinitions 5      �� 5      $
��373* �6    �� 5      $	��94* �6    .+�5      �� $��0��6   $	��Top=�6&   $��58��6>   ��5      �� 5       �� 
StartPoint$	 0,0&�6*    �� EndPoint$	 0,1&�6;   .��5      �  � Color$ 	#FF2C2C2C��6'    � Offset$ 0Q�69   � 5      $ 	#FF1F1F1F��6'   $ 1Q�69   5      .+�5      �  � ColumnDefinitions 5      �� 5      $��* �6+   �� 5       $
��Auto �6+   .+�5$      �� -   5        	 ��Name$	 
UserButton��5$      $��Witaj, Jan!��61      UserButtonStyle#��[  5%      $
��Left=�5&      $��Center=�5'      $��20,0,0,0q�5(      $��0��5)      5*      �� 5-      
 �� Orientation$
 
Horizontal=�6!   $��1��6:   .+�5.      �� -   5        $	 itemsInCartCounter��5.   !     CartButtonStyle#��[ 5/   !   $��0��50   !   $��50��51   !   $��56��52   !   $��0,5,50,5q�53   !    � Cursor$
 Hand��54   !   55   !   56      57      58      �� 5;      $��	0,70,0,50q�6   $
 
Horizontal=�6,   $��Center=�6E   $��2��6b   $
��1226��6s   .+�5=      �� -   5         ��Name$ 	BookCover��5=        BookCoverStyle#��[ 6+   $��Center=�6S   $	��Top=�6p   $��	50,0,50,0q�6�   �� 5?      $	��622��6   $	��676��6*   $	��Top=�66   .+�5@      �� -   5         ��Name$ 
book_title��5@       $��
Gra o tron��64     BookTitleStyleInBookInfo#��[ 6F   $
��Left=�6x   �� 5A      -   5        $ book_author��5A       $��George R.R. Martin��65     BookAuthorStyle#��[ 6O   $
��Left=�6x   �� 5B      -   5        $ 
book_price��5B       $��60 zł��64     BookPriceStyle#��[ 6A   $
��Left=�6i   �� 5C      -   5        $	 add_to_card_button��5C      $��Dodaj do koszyka��69     AddToCartButtonStyle#��[ 6T   $
��Left=�6�   6�   �� 5D         AdditionalInfoContainerStyle#��[ 6   $��10,75,10,10q�6S   $	��280��6h   ._�5E      �� .+�5F      �� $��Dodatkowe szczegóły��6(    �� TextAlignment$ Center=�5G   (   $��25(�5H   (   $
��Bold"�5I   (   ���#333333$��0,0,0,10q�5K   (   �� 5L      -   5        $ book_tag��5L   (   $��Gatunek: Fantasy��5M   (     AdditionalInfoTextStyle#��[ 5N   (   �� 5O      -	   5        $ book_language��5O   (   $��Język: Polski��5P   (   #��[ 5Q   (   �� 5R      -
   5        $ 
book_pages��5R   (   $��Liczba stron: 512��5S   (   #��[ 5T   (   �� 5V      -   5        $ booksCopies��5V   (   $��5q�6=   #��[ 5W       $&�� Ilość dostępnych egzempalrzy:��5X   (   �� 5Y      -   5        $ authorsNationality��5Y   (   #��[ 5Z      $��Narodowość autora :��5[      �� 5\      -   5        $ 	biography��5\   (   #��[ 5]   !   $�� ��5^   !   5_      5`      5a      5b      �� 5e      $��0,590,675,0q�6   $
 Hand��6.   .+�5f      �� $��Opis produktu��6   $ Center=�61   $��25(�6H   $
��Bold"�6V   �� 5g      -   5        $ book_description��5g      $��Opis produktu��66   $ Center=�6K   $��18(�6b   $��88��6p   �� 5h      -   5        $	 EditBook��5h      $��Edytuj książkę��6+   #��[ 6D   $	��185��6r   ���	#FF096B0A$
��Left=�6�   �� 5i      -   5        $	 BackToSearch��5i      $��Powrót��6/   #��[ 6@   $
��Left=�6n   $	��185��6�   6�   5j      5k      5l      5m      