   M S B A M L   `   `   `  ����E  ACryptoInfo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:CryptoInfo
CryptoInfo  5	          CryptoInfo.index   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:CryptoInfo     5	      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5
      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      $	��600��5        � Title$
  Home��5      $	��700��5       � 	Resources 5       �� 
TargetType   HeadingLabels �� Property �� Value&   System.Windows.Controls.DataGrid  CurrencyParams��%�  &	        &	 �     �� 5   
   " ��6   .�5      ��  � ��
 �����6+   �� 5       � ��$ 24(�6)   �� 5       � ��$ Center=�6;   5      �� 5   
   "  6   .�5      ��  � ��
 �����6+   �� 5       � ��$ 16(�6)   �� 5       � ��$ Center=�6;   �� 5       � ��$ 0,3,0,0q�60   �� 5       � ��$
 35,1q�6'   5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��85 �6   �� 5      $��* �6   .+�5   
   �� ���#151c24$��0��5!       �� Orientation$ Vertical=�5"      .+�5#      �� 
������ $��0q�5%      $��24(�5&      
�������$��Center=�5(      .��65   Home5*      5+      �� 5,   
   ���#202a36$��1��5.      $ Vertical=�5/      .+�50      �� $��40��6   .+�51      �� $��Top 10 Currencies��6   #��[  64   52        53         AutoGenerateColumns$ False��6      HeadersVisibility$ Column=�63   $	��200��6N   $	��400��6[   	   Columns	 54      0  *System.Windows.Controls.DataGridTextColumn  56      ,  &System.Windows.Controls.DataGridColumn
   Header$

 Name��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *Name+   ElementStyle 57      �� 58      " ��6$   .�59   "   ��  � ��
 ��  �6?   �� 5:   "    � ��$ 14(�6=   �� 5;   "    � ��$
 Bold"�6?   5<         EditingElementStyle 5>      �� 5?      " ��6$   .�5@   "   ��  � ��
 �  ��6?   �� 5A   "    � ��$ 14(�6=   �� 5B   "    � ��$
 Bold"�6?   5C      5E        5H      $	
 Age��6)    66   �� *Age+ 5I      �� 5J      " ��6$   .�5K   "   ��  � ��
 � � �6?   �� 5L   "    � ��$ 12(�6=   5M       5O      �� 5P      " ��6$   .�5Q   "   ��  � ��
 � ���6?   �� 5R   "    � ��$ 12(�6=   5S      5U      5W      �� 5X      .+�5Y      �� 5Z      5\      5^      5_      