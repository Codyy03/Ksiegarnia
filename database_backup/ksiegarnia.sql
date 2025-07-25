PGDMP  &                    }        
   Ksiegarnia    17.0    17.0 J               0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                           false                       0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                           false            	           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                           false            
           1262    26110 
   Ksiegarnia    DATABASE        CREATE DATABASE "Ksiegarnia" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Polish_Poland.1250';
    DROP DATABASE "Ksiegarnia";
                     postgres    false                       0    0    DATABASE "Ksiegarnia"    ACL     a   GRANT ALL ON DATABASE "Ksiegarnia" TO admin_user;
GRANT CONNECT ON DATABASE "Ksiegarnia" TO jan;
                        postgres    false    4874            �            1259    26111    Adres    TABLE     �   CREATE TABLE public."Adres" (
    "ID" integer NOT NULL,
    miejscowosc text NOT NULL,
    ulica text NOT NULL,
    numer_mieszkania text,
    kod_pocztowy text NOT NULL,
    numer_domu text DEFAULT 10 NOT NULL
);
    DROP TABLE public."Adres";
       public         heap r       postgres    false                       0    0    TABLE "Adres"    ACL     4   GRANT SELECT,INSERT ON TABLE public."Adres" TO jan;
          public               postgres    false    217            �            1259    26117    Adres_ID_seq    SEQUENCE     �   CREATE SEQUENCE public."Adres_ID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 %   DROP SEQUENCE public."Adres_ID_seq";
       public               postgres    false    217                       0    0    Adres_ID_seq    SEQUENCE OWNED BY     C   ALTER SEQUENCE public."Adres_ID_seq" OWNED BY public."Adres"."ID";
          public               postgres    false    218            �            1259    26118    Autorzy    TABLE     �   CREATE TABLE public."Autorzy" (
    "ID" integer NOT NULL,
    imie text NOT NULL,
    nazwisko text NOT NULL,
    narodowosc text NOT NULL,
    biografia text NOT NULL
);
    DROP TABLE public."Autorzy";
       public         heap r       postgres    false                       0    0    TABLE "Autorzy"    ACL     6   GRANT SELECT,INSERT ON TABLE public."Autorzy" TO jan;
          public               postgres    false    219            �            1259    26123    Autorzy_ID_seq    SEQUENCE     �   CREATE SEQUENCE public."Autorzy_ID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 '   DROP SEQUENCE public."Autorzy_ID_seq";
       public               postgres    false    219                       0    0    Autorzy_ID_seq    SEQUENCE OWNED BY     G   ALTER SEQUENCE public."Autorzy_ID_seq" OWNED BY public."Autorzy"."ID";
          public               postgres    false    220            �            1259    26124    Autorzy_Ksiazki    TABLE     �   CREATE TABLE public."Autorzy_Ksiazki" (
    "ID" integer NOT NULL,
    "ID_Autora" integer NOT NULL,
    "ID_Ksiazki" integer NOT NULL
);
 %   DROP TABLE public."Autorzy_Ksiazki";
       public         heap r       postgres    false                       0    0    TABLE "Autorzy_Ksiazki"    ACL     >   GRANT SELECT,INSERT ON TABLE public."Autorzy_Ksiazki" TO jan;
          public               postgres    false    221            �            1259    26127    Autorzy_Ksiazki_ID_seq    SEQUENCE     �   CREATE SEQUENCE public."Autorzy_Ksiazki_ID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 /   DROP SEQUENCE public."Autorzy_Ksiazki_ID_seq";
       public               postgres    false    221                       0    0    Autorzy_Ksiazki_ID_seq    SEQUENCE OWNED BY     W   ALTER SEQUENCE public."Autorzy_Ksiazki_ID_seq" OWNED BY public."Autorzy_Ksiazki"."ID";
          public               postgres    false    222            �            1259    26128    Klienci    TABLE     �   CREATE TABLE public."Klienci" (
    "ID" integer NOT NULL,
    imie text NOT NULL,
    nazwisko text NOT NULL,
    email text NOT NULL,
    haslo text NOT NULL,
    telefon text NOT NULL,
    "ID_Adresu" integer
);
    DROP TABLE public."Klienci";
       public         heap r       postgres    false                       0    0    TABLE "Klienci"    ACL     6   GRANT SELECT,INSERT ON TABLE public."Klienci" TO jan;
          public               postgres    false    223            �            1259    26133    Klienci_ID_seq    SEQUENCE     �   CREATE SEQUENCE public."Klienci_ID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 '   DROP SEQUENCE public."Klienci_ID_seq";
       public               postgres    false    223                       0    0    Klienci_ID_seq    SEQUENCE OWNED BY     G   ALTER SEQUENCE public."Klienci_ID_seq" OWNED BY public."Klienci"."ID";
          public               postgres    false    224            �            1259    26134    Ksiazki    TABLE     '  CREATE TABLE public."Ksiazki" (
    "ID" integer NOT NULL,
    tytul text NOT NULL,
    gatunek text NOT NULL,
    opis text NOT NULL,
    cena numeric(10,2) NOT NULL,
    jezyk text NOT NULL,
    ilosc_stron integer NOT NULL,
    nazwa_obrazu text NOT NULL,
    "ID_Autora" integer NOT NULL
);
    DROP TABLE public."Ksiazki";
       public         heap r       postgres    false                       0    0    TABLE "Ksiazki"    ACL     6   GRANT SELECT,INSERT ON TABLE public."Ksiazki" TO jan;
          public               postgres    false    225            �            1259    26139    Ksiazki_ID_seq    SEQUENCE     �   CREATE SEQUENCE public."Ksiazki_ID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 '   DROP SEQUENCE public."Ksiazki_ID_seq";
       public               postgres    false    225                       0    0    Ksiazki_ID_seq    SEQUENCE OWNED BY     G   ALTER SEQUENCE public."Ksiazki_ID_seq" OWNED BY public."Ksiazki"."ID";
          public               postgres    false    226            �            1259    26140 
   Zamowienia    TABLE     �   CREATE TABLE public."Zamowienia" (
    "ID" integer NOT NULL,
    data_zamowienia date NOT NULL,
    kwota numeric(10,2) NOT NULL,
    "ID_Klienta" integer NOT NULL
);
     DROP TABLE public."Zamowienia";
       public         heap r       postgres    false                       0    0    TABLE "Zamowienia"    ACL     9   GRANT SELECT,INSERT ON TABLE public."Zamowienia" TO jan;
          public               postgres    false    227            �            1259    26143    Zamowienia_ID_seq    SEQUENCE     �   CREATE SEQUENCE public."Zamowienia_ID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 *   DROP SEQUENCE public."Zamowienia_ID_seq";
       public               postgres    false    227                       0    0    Zamowienia_ID_seq    SEQUENCE OWNED BY     M   ALTER SEQUENCE public."Zamowienia_ID_seq" OWNED BY public."Zamowienia"."ID";
          public               postgres    false    228            �            1259    26144    Zamowienia_Ksiazki    TABLE     �   CREATE TABLE public."Zamowienia_Ksiazki" (
    "ID" integer NOT NULL,
    "ID_Zamowienia" integer NOT NULL,
    "ID_Ksiazki" integer NOT NULL,
    ilosc integer NOT NULL,
    cena_ksiazki numeric(10,2) NOT NULL
);
 (   DROP TABLE public."Zamowienia_Ksiazki";
       public         heap r       postgres    false                       0    0    TABLE "Zamowienia_Ksiazki"    ACL     A   GRANT SELECT,INSERT ON TABLE public."Zamowienia_Ksiazki" TO jan;
          public               postgres    false    229            �            1259    26147    Zamowienia_Ksiazki_ID_seq    SEQUENCE     �   CREATE SEQUENCE public."Zamowienia_Ksiazki_ID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 2   DROP SEQUENCE public."Zamowienia_Ksiazki_ID_seq";
       public               postgres    false    229                       0    0    Zamowienia_Ksiazki_ID_seq    SEQUENCE OWNED BY     ]   ALTER SEQUENCE public."Zamowienia_Ksiazki_ID_seq" OWNED BY public."Zamowienia_Ksiazki"."ID";
          public               postgres    false    230            �            1259    26148    __EFMigrationsHistory    TABLE     �   CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);
 +   DROP TABLE public."__EFMigrationsHistory";
       public         heap r       postgres    false                       0    0    TABLE "__EFMigrationsHistory"    ACL     D   GRANT SELECT,INSERT ON TABLE public."__EFMigrationsHistory" TO jan;
          public               postgres    false    231            D           2604    26151    Adres ID    DEFAULT     j   ALTER TABLE ONLY public."Adres" ALTER COLUMN "ID" SET DEFAULT nextval('public."Adres_ID_seq"'::regclass);
 ;   ALTER TABLE public."Adres" ALTER COLUMN "ID" DROP DEFAULT;
       public               postgres    false    218    217            F           2604    26152 
   Autorzy ID    DEFAULT     n   ALTER TABLE ONLY public."Autorzy" ALTER COLUMN "ID" SET DEFAULT nextval('public."Autorzy_ID_seq"'::regclass);
 =   ALTER TABLE public."Autorzy" ALTER COLUMN "ID" DROP DEFAULT;
       public               postgres    false    220    219            G           2604    26153    Autorzy_Ksiazki ID    DEFAULT     ~   ALTER TABLE ONLY public."Autorzy_Ksiazki" ALTER COLUMN "ID" SET DEFAULT nextval('public."Autorzy_Ksiazki_ID_seq"'::regclass);
 E   ALTER TABLE public."Autorzy_Ksiazki" ALTER COLUMN "ID" DROP DEFAULT;
       public               postgres    false    222    221            H           2604    26154 
   Klienci ID    DEFAULT     n   ALTER TABLE ONLY public."Klienci" ALTER COLUMN "ID" SET DEFAULT nextval('public."Klienci_ID_seq"'::regclass);
 =   ALTER TABLE public."Klienci" ALTER COLUMN "ID" DROP DEFAULT;
       public               postgres    false    224    223            I           2604    26155 
   Ksiazki ID    DEFAULT     n   ALTER TABLE ONLY public."Ksiazki" ALTER COLUMN "ID" SET DEFAULT nextval('public."Ksiazki_ID_seq"'::regclass);
 =   ALTER TABLE public."Ksiazki" ALTER COLUMN "ID" DROP DEFAULT;
       public               postgres    false    226    225            J           2604    26156    Zamowienia ID    DEFAULT     t   ALTER TABLE ONLY public."Zamowienia" ALTER COLUMN "ID" SET DEFAULT nextval('public."Zamowienia_ID_seq"'::regclass);
 @   ALTER TABLE public."Zamowienia" ALTER COLUMN "ID" DROP DEFAULT;
       public               postgres    false    228    227            K           2604    26157    Zamowienia_Ksiazki ID    DEFAULT     �   ALTER TABLE ONLY public."Zamowienia_Ksiazki" ALTER COLUMN "ID" SET DEFAULT nextval('public."Zamowienia_Ksiazki_ID_seq"'::regclass);
 H   ALTER TABLE public."Zamowienia_Ksiazki" ALTER COLUMN "ID" DROP DEFAULT;
       public               postgres    false    230    229            �          0    26111    Adres 
   TABLE DATA           g   COPY public."Adres" ("ID", miejscowosc, ulica, numer_mieszkania, kod_pocztowy, numer_domu) FROM stdin;
    public               postgres    false    217   �U       �          0    26118    Autorzy 
   TABLE DATA           P   COPY public."Autorzy" ("ID", imie, nazwisko, narodowosc, biografia) FROM stdin;
    public               postgres    false    219   mV       �          0    26124    Autorzy_Ksiazki 
   TABLE DATA           L   COPY public."Autorzy_Ksiazki" ("ID", "ID_Autora", "ID_Ksiazki") FROM stdin;
    public               postgres    false    221   iX       �          0    26128    Klienci 
   TABLE DATA           ]   COPY public."Klienci" ("ID", imie, nazwisko, email, haslo, telefon, "ID_Adresu") FROM stdin;
    public               postgres    false    223   �X       �          0    26134    Ksiazki 
   TABLE DATA           t   COPY public."Ksiazki" ("ID", tytul, gatunek, opis, cena, jezyk, ilosc_stron, nazwa_obrazu, "ID_Autora") FROM stdin;
    public               postgres    false    225   �Y                  0    26140 
   Zamowienia 
   TABLE DATA           R   COPY public."Zamowienia" ("ID", data_zamowienia, kwota, "ID_Klienta") FROM stdin;
    public               postgres    false    227   �\                 0    26144    Zamowienia_Ksiazki 
   TABLE DATA           h   COPY public."Zamowienia_Ksiazki" ("ID", "ID_Zamowienia", "ID_Ksiazki", ilosc, cena_ksiazki) FROM stdin;
    public               postgres    false    229   ']                 0    26148    __EFMigrationsHistory 
   TABLE DATA           R   COPY public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") FROM stdin;
    public               postgres    false    231   �]                  0    0    Adres_ID_seq    SEQUENCE SET     <   SELECT pg_catalog.setval('public."Adres_ID_seq"', 5, true);
          public               postgres    false    218                       0    0    Autorzy_ID_seq    SEQUENCE SET     ?   SELECT pg_catalog.setval('public."Autorzy_ID_seq"', 45, true);
          public               postgres    false    220                       0    0    Autorzy_Ksiazki_ID_seq    SEQUENCE SET     F   SELECT pg_catalog.setval('public."Autorzy_Ksiazki_ID_seq"', 5, true);
          public               postgres    false    222                       0    0    Klienci_ID_seq    SEQUENCE SET     >   SELECT pg_catalog.setval('public."Klienci_ID_seq"', 5, true);
          public               postgres    false    224                       0    0    Ksiazki_ID_seq    SEQUENCE SET     ?   SELECT pg_catalog.setval('public."Ksiazki_ID_seq"', 26, true);
          public               postgres    false    226                        0    0    Zamowienia_ID_seq    SEQUENCE SET     B   SELECT pg_catalog.setval('public."Zamowienia_ID_seq"', 13, true);
          public               postgres    false    228            !           0    0    Zamowienia_Ksiazki_ID_seq    SEQUENCE SET     J   SELECT pg_catalog.setval('public."Zamowienia_Ksiazki_ID_seq"', 11, true);
          public               postgres    false    230            M           2606    26159    Adres Adres_pkey 
   CONSTRAINT     T   ALTER TABLE ONLY public."Adres"
    ADD CONSTRAINT "Adres_pkey" PRIMARY KEY ("ID");
 >   ALTER TABLE ONLY public."Adres" DROP CONSTRAINT "Adres_pkey";
       public                 postgres    false    217            Q           2606    26161 $   Autorzy_Ksiazki Autorzy_Ksiazki_pkey 
   CONSTRAINT     h   ALTER TABLE ONLY public."Autorzy_Ksiazki"
    ADD CONSTRAINT "Autorzy_Ksiazki_pkey" PRIMARY KEY ("ID");
 R   ALTER TABLE ONLY public."Autorzy_Ksiazki" DROP CONSTRAINT "Autorzy_Ksiazki_pkey";
       public                 postgres    false    221            O           2606    26163    Autorzy Autorzy_pkey 
   CONSTRAINT     X   ALTER TABLE ONLY public."Autorzy"
    ADD CONSTRAINT "Autorzy_pkey" PRIMARY KEY ("ID");
 B   ALTER TABLE ONLY public."Autorzy" DROP CONSTRAINT "Autorzy_pkey";
       public                 postgres    false    219            S           2606    26165    Klienci Klienci_email_key 
   CONSTRAINT     Y   ALTER TABLE ONLY public."Klienci"
    ADD CONSTRAINT "Klienci_email_key" UNIQUE (email);
 G   ALTER TABLE ONLY public."Klienci" DROP CONSTRAINT "Klienci_email_key";
       public                 postgres    false    223            U           2606    26167    Klienci Klienci_pkey 
   CONSTRAINT     X   ALTER TABLE ONLY public."Klienci"
    ADD CONSTRAINT "Klienci_pkey" PRIMARY KEY ("ID");
 B   ALTER TABLE ONLY public."Klienci" DROP CONSTRAINT "Klienci_pkey";
       public                 postgres    false    223            W           2606    26169    Ksiazki Ksiazki_pkey 
   CONSTRAINT     X   ALTER TABLE ONLY public."Ksiazki"
    ADD CONSTRAINT "Ksiazki_pkey" PRIMARY KEY ("ID");
 B   ALTER TABLE ONLY public."Ksiazki" DROP CONSTRAINT "Ksiazki_pkey";
       public                 postgres    false    225            ]           2606    26171 .   __EFMigrationsHistory PK___EFMigrationsHistory 
   CONSTRAINT     {   ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");
 \   ALTER TABLE ONLY public."__EFMigrationsHistory" DROP CONSTRAINT "PK___EFMigrationsHistory";
       public                 postgres    false    231            [           2606    26173 *   Zamowienia_Ksiazki Zamowienia_Ksiazki_pkey 
   CONSTRAINT     n   ALTER TABLE ONLY public."Zamowienia_Ksiazki"
    ADD CONSTRAINT "Zamowienia_Ksiazki_pkey" PRIMARY KEY ("ID");
 X   ALTER TABLE ONLY public."Zamowienia_Ksiazki" DROP CONSTRAINT "Zamowienia_Ksiazki_pkey";
       public                 postgres    false    229            Y           2606    26175    Zamowienia Zamowienia_pkey 
   CONSTRAINT     ^   ALTER TABLE ONLY public."Zamowienia"
    ADD CONSTRAINT "Zamowienia_pkey" PRIMARY KEY ("ID");
 H   ALTER TABLE ONLY public."Zamowienia" DROP CONSTRAINT "Zamowienia_pkey";
       public                 postgres    false    227            ^           2606    26176 .   Autorzy_Ksiazki Autorzy_Ksiazki_ID_Autora_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Autorzy_Ksiazki"
    ADD CONSTRAINT "Autorzy_Ksiazki_ID_Autora_fkey" FOREIGN KEY ("ID_Autora") REFERENCES public."Autorzy"("ID");
 \   ALTER TABLE ONLY public."Autorzy_Ksiazki" DROP CONSTRAINT "Autorzy_Ksiazki_ID_Autora_fkey";
       public               postgres    false    4687    221    219            _           2606    26230 /   Autorzy_Ksiazki Autorzy_Ksiazki_ID_Ksiazki_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Autorzy_Ksiazki"
    ADD CONSTRAINT "Autorzy_Ksiazki_ID_Ksiazki_fkey" FOREIGN KEY ("ID_Ksiazki") REFERENCES public."Ksiazki"("ID") ON DELETE CASCADE;
 ]   ALTER TABLE ONLY public."Autorzy_Ksiazki" DROP CONSTRAINT "Autorzy_Ksiazki_ID_Ksiazki_fkey";
       public               postgres    false    221    225    4695            `           2606    26186    Klienci Klienci_ID_Adresu_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Klienci"
    ADD CONSTRAINT "Klienci_ID_Adresu_fkey" FOREIGN KEY ("ID_Adresu") REFERENCES public."Adres"("ID");
 L   ALTER TABLE ONLY public."Klienci" DROP CONSTRAINT "Klienci_ID_Adresu_fkey";
       public               postgres    false    4685    217    223            a           2606    26191    Ksiazki Ksiazki_ID_Autora_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Ksiazki"
    ADD CONSTRAINT "Ksiazki_ID_Autora_fkey" FOREIGN KEY ("ID_Autora") REFERENCES public."Autorzy"("ID");
 L   ALTER TABLE ONLY public."Ksiazki" DROP CONSTRAINT "Ksiazki_ID_Autora_fkey";
       public               postgres    false    225    4687    219            b           2606    26196 %   Zamowienia Zamowienia_ID_Klienta_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Zamowienia"
    ADD CONSTRAINT "Zamowienia_ID_Klienta_fkey" FOREIGN KEY ("ID_Klienta") REFERENCES public."Klienci"("ID");
 S   ALTER TABLE ONLY public."Zamowienia" DROP CONSTRAINT "Zamowienia_ID_Klienta_fkey";
       public               postgres    false    227    223    4693            c           2606    26225 5   Zamowienia_Ksiazki Zamowienia_Ksiazki_ID_Ksiazki_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Zamowienia_Ksiazki"
    ADD CONSTRAINT "Zamowienia_Ksiazki_ID_Ksiazki_fkey" FOREIGN KEY ("ID_Ksiazki") REFERENCES public."Ksiazki"("ID") ON DELETE CASCADE;
 c   ALTER TABLE ONLY public."Zamowienia_Ksiazki" DROP CONSTRAINT "Zamowienia_Ksiazki_ID_Ksiazki_fkey";
       public               postgres    false    225    229    4695            d           2606    26206 8   Zamowienia_Ksiazki Zamowienia_Ksiazki_ID_Zamowienia_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Zamowienia_Ksiazki"
    ADD CONSTRAINT "Zamowienia_Ksiazki_ID_Zamowienia_fkey" FOREIGN KEY ("ID_Zamowienia") REFERENCES public."Zamowienia"("ID");
 f   ALTER TABLE ONLY public."Zamowienia_Ksiazki" DROP CONSTRAINT "Zamowienia_Ksiazki_ID_Zamowienia_fkey";
       public               postgres    false    4697    229    227                       826    26213    DEFAULT PRIVILEGES FOR TABLES    DEFAULT ACL     b   ALTER DEFAULT PRIVILEGES FOR ROLE postgres IN SCHEMA public GRANT SELECT,INSERT ON TABLES TO jan;
          public               postgres    false            �   �   x�-�M
�0D��S��/I���PPqӍ�P���R����%�As/[uvÛyk����b�U����Ru�!9�@��'���5K7\�
B !�H>� ��s7��<@H�ӗ���}5��m�_:�l^T��8��G�lӫV����'������,΍)4�p�������yg8�      �   �  x������0���S��!�Yh�	���k��@�e"k��mM�e�t}��G�qo��~���dY�������k*�4b��B�QE�S�V �a������`"���@��]Pф��w�Uh����29�Y��`@~�Bwm�4K�Ľ���6�3�R�mC��a���l�H9[������8��_
ei)����6dɵ�D`�+���_���n`?U'pg2_��"J����Ȝ��6�,���)�ډ{�W�Y�ş���(�"����G�	�@\�.�?dڍ��ɖZ��U&�`�W���y�V�6J�T�\�I�����ݕ�gS��Z������'�'0JC^�ȱI��1��y�Mǿ_��;�m�3+�D]��(��}3K��R��c9)��Tat=��-`��?l�-���\��.Y����%����v#n&n�
����vz��Uܷ����BY�97�}�u�ɸ���{3�W���JKN=2�{�$�?��6^      �       x�3�4�4�2�B.N �2�B�=... 5�      �   �   x�U��N�0����X��%�@��8DGC�\��%�sv���<��E��P��f?ifG+pK���O�É<���ʾ�0��ÀWJ}RamvU�@0�k�	���-��"7�d�oю�������d
.L����;����]Z�&�m������VJA1�EG���x�a1�xK�	�R$��B!�,)���eN�)���f�m�-��Q���M�d�T>��i꺮�
�=q���qQ      �     x�͔�r�6���S`r�I�H���[=������hb��ˊD(P�P8�Q�N���G�1��o1�+KR�����H|v��G"(��ז�*e�2 �BVAs_p�i�hb9k��2�;�RI�P�ڊ����lF�n���l�)�Ϯˇ|���o׋�Ed����YìL��x3r�Q2)8PNw� w����/Z�:��\�<��E�>���+/�62cU�5$a8��oR�Y�3��l������=�|В;����km���is�@�O�
ϋxq�*mkj7��WEe�	4���7�%�?���Ι�<�lH�~�t,�q��hi�����\<Vb��^��b��x�d�heS��c}tLSi�xwZ�W��5�T�0߾t�	G�"����z�����݃���Bǻ +���؟4�nќ`�}ږn�9 ��7�-�dX�7'�?���[�����t  ?{���&d	����&�R�L�A4R{��O�:��Iƛl���y聞�נTM#iSX��|�W<�V~h�Y�7 @c��wg����!p��Z�`�p��}W�p�cz�t���x<�/�mk1(;��-pB2W�[��ӈ)����Q[��ӥL�x��S��qZ����ϵc�����M��t���=y>�7%����ƛ���7gR��'�תby�	J97�
l|���6U{'����l�����U�1Qk��i��#kI^K��"��x�4��=����H�[�Nj�SP�����	ڰ��0|ᨭ���hx���KV���:�����~:���?�          n   x�mϻ�@К�E�~��]��9#�;�$H�R�� $7��c�#�6���yaIolu"jl-�J�i��FGd؜k�|Օn������[�����/�^(5         P   x�M��	�@��bD=M�^�Q!d�aV�tf%g�j�u<8^�j7tT/�"�y���e��\�+*E����b 7�+            x������ � �     