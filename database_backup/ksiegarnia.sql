--
-- PostgreSQL database dump
--

-- Dumped from database version 17.2
-- Dumped by pg_dump version 17.2

-- Started on 2025-04-19 16:11:29

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 218 (class 1259 OID 34301)
-- Name: Adres; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Adres" (
    "ID" integer NOT NULL,
    miejscowosc text NOT NULL,
    ulica text NOT NULL,
    numer_mieszkania text,
    kod_pocztowy text NOT NULL
);


ALTER TABLE public."Adres" OWNER TO postgres;

--
-- TOC entry 217 (class 1259 OID 34300)
-- Name: Adres_ID_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Adres_ID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Adres_ID_seq" OWNER TO postgres;

--
-- TOC entry 4865 (class 0 OID 0)
-- Dependencies: 217
-- Name: Adres_ID_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Adres_ID_seq" OWNED BY public."Adres"."ID";


--
-- TOC entry 222 (class 1259 OID 34326)
-- Name: Autorzy; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Autorzy" (
    "ID" integer NOT NULL,
    imie text NOT NULL,
    nazwisko text NOT NULL,
    narodowosc text NOT NULL,
    biografia text NOT NULL
);


ALTER TABLE public."Autorzy" OWNER TO postgres;

--
-- TOC entry 221 (class 1259 OID 34325)
-- Name: Autorzy_ID_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Autorzy_ID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Autorzy_ID_seq" OWNER TO postgres;

--
-- TOC entry 4866 (class 0 OID 0)
-- Dependencies: 221
-- Name: Autorzy_ID_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Autorzy_ID_seq" OWNED BY public."Autorzy"."ID";


--
-- TOC entry 230 (class 1259 OID 34378)
-- Name: Autorzy_Ksiazki; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Autorzy_Ksiazki" (
    "ID" integer NOT NULL,
    "ID_Autora" integer NOT NULL,
    "ID_Ksiazki" integer NOT NULL
);


ALTER TABLE public."Autorzy_Ksiazki" OWNER TO postgres;

--
-- TOC entry 229 (class 1259 OID 34377)
-- Name: Autorzy_Ksiazki_ID_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Autorzy_Ksiazki_ID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Autorzy_Ksiazki_ID_seq" OWNER TO postgres;

--
-- TOC entry 4867 (class 0 OID 0)
-- Dependencies: 229
-- Name: Autorzy_Ksiazki_ID_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Autorzy_Ksiazki_ID_seq" OWNED BY public."Autorzy_Ksiazki"."ID";


--
-- TOC entry 220 (class 1259 OID 34310)
-- Name: Klienci; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Klienci" (
    "ID" integer NOT NULL,
    imie text NOT NULL,
    nazwisko text NOT NULL,
    email text NOT NULL,
    haslo text NOT NULL,
    telefon text NOT NULL,
    "ID_Adresu" integer
);


ALTER TABLE public."Klienci" OWNER TO postgres;

--
-- TOC entry 219 (class 1259 OID 34309)
-- Name: Klienci_ID_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Klienci_ID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Klienci_ID_seq" OWNER TO postgres;

--
-- TOC entry 4868 (class 0 OID 0)
-- Dependencies: 219
-- Name: Klienci_ID_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Klienci_ID_seq" OWNED BY public."Klienci"."ID";


--
-- TOC entry 224 (class 1259 OID 34335)
-- Name: Ksiazki; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Ksiazki" (
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


ALTER TABLE public."Ksiazki" OWNER TO postgres;

--
-- TOC entry 223 (class 1259 OID 34334)
-- Name: Ksiazki_ID_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Ksiazki_ID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Ksiazki_ID_seq" OWNER TO postgres;

--
-- TOC entry 4869 (class 0 OID 0)
-- Dependencies: 223
-- Name: Ksiazki_ID_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Ksiazki_ID_seq" OWNED BY public."Ksiazki"."ID";


--
-- TOC entry 226 (class 1259 OID 34349)
-- Name: Zamowienia; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Zamowienia" (
    "ID" integer NOT NULL,
    data_zamowienia date NOT NULL,
    kwota numeric(10,2) NOT NULL,
    "ID_Klienta" integer NOT NULL
);


ALTER TABLE public."Zamowienia" OWNER TO postgres;

--
-- TOC entry 225 (class 1259 OID 34348)
-- Name: Zamowienia_ID_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Zamowienia_ID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Zamowienia_ID_seq" OWNER TO postgres;

--
-- TOC entry 4870 (class 0 OID 0)
-- Dependencies: 225
-- Name: Zamowienia_ID_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Zamowienia_ID_seq" OWNED BY public."Zamowienia"."ID";


--
-- TOC entry 228 (class 1259 OID 34361)
-- Name: Zamowienia_Ksiazki; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Zamowienia_Ksiazki" (
    "ID" integer NOT NULL,
    "ID_Zamowienia" integer NOT NULL,
    "ID_Ksiazki" integer NOT NULL,
    ilosc integer NOT NULL,
    cena_ksiazki numeric(10,2) NOT NULL
);


ALTER TABLE public."Zamowienia_Ksiazki" OWNER TO postgres;

--
-- TOC entry 227 (class 1259 OID 34360)
-- Name: Zamowienia_Ksiazki_ID_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Zamowienia_Ksiazki_ID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Zamowienia_Ksiazki_ID_seq" OWNER TO postgres;

--
-- TOC entry 4871 (class 0 OID 0)
-- Dependencies: 227
-- Name: Zamowienia_Ksiazki_ID_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Zamowienia_Ksiazki_ID_seq" OWNED BY public."Zamowienia_Ksiazki"."ID";


--
-- TOC entry 4671 (class 2604 OID 34304)
-- Name: Adres ID; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Adres" ALTER COLUMN "ID" SET DEFAULT nextval('public."Adres_ID_seq"'::regclass);


--
-- TOC entry 4673 (class 2604 OID 34329)
-- Name: Autorzy ID; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Autorzy" ALTER COLUMN "ID" SET DEFAULT nextval('public."Autorzy_ID_seq"'::regclass);


--
-- TOC entry 4677 (class 2604 OID 34381)
-- Name: Autorzy_Ksiazki ID; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Autorzy_Ksiazki" ALTER COLUMN "ID" SET DEFAULT nextval('public."Autorzy_Ksiazki_ID_seq"'::regclass);


--
-- TOC entry 4672 (class 2604 OID 34313)
-- Name: Klienci ID; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Klienci" ALTER COLUMN "ID" SET DEFAULT nextval('public."Klienci_ID_seq"'::regclass);


--
-- TOC entry 4674 (class 2604 OID 34338)
-- Name: Ksiazki ID; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Ksiazki" ALTER COLUMN "ID" SET DEFAULT nextval('public."Ksiazki_ID_seq"'::regclass);


--
-- TOC entry 4675 (class 2604 OID 34352)
-- Name: Zamowienia ID; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Zamowienia" ALTER COLUMN "ID" SET DEFAULT nextval('public."Zamowienia_ID_seq"'::regclass);


--
-- TOC entry 4676 (class 2604 OID 34364)
-- Name: Zamowienia_Ksiazki ID; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Zamowienia_Ksiazki" ALTER COLUMN "ID" SET DEFAULT nextval('public."Zamowienia_Ksiazki_ID_seq"'::regclass);


--
-- TOC entry 4847 (class 0 OID 34301)
-- Dependencies: 218
-- Data for Name: Adres; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Adres" ("ID", miejscowosc, ulica, numer_mieszkania, kod_pocztowy) FROM stdin;
1	Warszawa	Aleje Jerozolimskie	45/12	00-001
2	Kraków	Rynek Główny	7	31-042
3	Gdańsk	Długa	22	80-831
4	Wrocław	Rynek	14	50-101
5	Poznań	Święty Marcin	33	60-786
\.


--
-- TOC entry 4851 (class 0 OID 34326)
-- Dependencies: 222
-- Data for Name: Autorzy; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Autorzy" ("ID", imie, nazwisko, narodowosc, biografia) FROM stdin;
1	Adam	Mickiewicz	Polska	Wybitny polski poeta, działacz polityczny, publicysta, tłumacz. Autor "Pana Tadeusza".
2	Stephen	King	Amerykańska	Amerykański pisarz, autor horrorów, powieści grozy i fantasy.
3	Joanne	Rowling	Brytyjska	Brytyjska pisarka, autorka serii o Harrym Potterze.
4	Andrzej	Sapkowski	Polska	Polski pisarz fantasy, twórca sagi o Wiedźminie.
5	George R.R.	Martin	Amerykańska	Amerykański pisarz fantasy i science fiction, autor "Pieśni Lodu i Ognia".
\.


--
-- TOC entry 4859 (class 0 OID 34378)
-- Dependencies: 230
-- Data for Name: Autorzy_Ksiazki; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Autorzy_Ksiazki" ("ID", "ID_Autora", "ID_Ksiazki") FROM stdin;
1	1	1
2	2	2
3	3	3
4	4	4
5	5	5
\.


--
-- TOC entry 4849 (class 0 OID 34310)
-- Dependencies: 220
-- Data for Name: Klienci; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Klienci" ("ID", imie, nazwisko, email, haslo, telefon, "ID_Adresu") FROM stdin;
1	Jan	Kowalski	jan.kowalski@example.com	haslo123	123456789	1
2	Anna	Nowak	anna.nowak@example.com	securepass	987654321	2
3	Piotr	Wiśniewski	piotr.wisniewski@example.com	qwerty123	555444333	3
4	Maria	Dąbrowska	maria.dabrowska@example.com	mypassword	111222333	4
5	Krzysztof	Lewandowski	krzysztof.lewandowski@example.com	test1234	999888777	5
\.


--
-- TOC entry 4853 (class 0 OID 34335)
-- Dependencies: 224
-- Data for Name: Ksiazki; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Ksiazki" ("ID", tytul, gatunek, opis, cena, jezyk, ilosc_stron, nazwa_obrazu, "ID_Autora") FROM stdin;
1	Pan Tadeusz	Epopeja	Najważniejsze dzieło polskiego romantyzmu.	39.99	Polski	320	pan_tadeusz.jpg	1
2	To	Horror	Przerażająca historia o kosmicznym złu w małym miasteczku.	49.99	Angielski	1138	to.jpg	2
3	Harry Potter i Kamień Filozoficzny	Fantasy	Pierwsza część serii o młodym czarodzieju.	45.50	Polski	328	harry_potter.jpg	3
4	Ostatnie życzenie	Fantasy	Pierwszy zbiór opowiadań o Wiedźminie Geralcie.	42.00	Polski	288	wiedzmin.jpg	4
5	Gra o tron	Fantasy	Pierwszy tom sagi "Pieśni Lodu i Ognia".	55.00	Polski	512	gra_o_tron.jpg	5
\.


--
-- TOC entry 4855 (class 0 OID 34349)
-- Dependencies: 226
-- Data for Name: Zamowienia; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Zamowienia" ("ID", data_zamowienia, kwota, "ID_Klienta") FROM stdin;
1	2023-01-15	85.49	1
2	2023-02-20	97.50	2
3	2023-03-10	45.50	3
4	2023-04-05	139.99	4
5	2023-05-12	55.00	5
\.


--
-- TOC entry 4857 (class 0 OID 34361)
-- Dependencies: 228
-- Data for Name: Zamowienia_Ksiazki; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Zamowienia_Ksiazki" ("ID", "ID_Zamowienia", "ID_Ksiazki", ilosc, cena_ksiazki) FROM stdin;
1	1	1	1	39.99
2	1	4	1	42.00
3	2	3	2	45.50
4	3	3	1	45.50
5	4	2	1	49.99
6	4	5	1	55.00
7	4	1	1	39.99
8	5	5	1	55.00
\.


--
-- TOC entry 4872 (class 0 OID 0)
-- Dependencies: 217
-- Name: Adres_ID_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Adres_ID_seq"', 5, true);


--
-- TOC entry 4873 (class 0 OID 0)
-- Dependencies: 221
-- Name: Autorzy_ID_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Autorzy_ID_seq"', 5, true);


--
-- TOC entry 4874 (class 0 OID 0)
-- Dependencies: 229
-- Name: Autorzy_Ksiazki_ID_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Autorzy_Ksiazki_ID_seq"', 5, true);


--
-- TOC entry 4875 (class 0 OID 0)
-- Dependencies: 219
-- Name: Klienci_ID_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Klienci_ID_seq"', 5, true);


--
-- TOC entry 4876 (class 0 OID 0)
-- Dependencies: 223
-- Name: Ksiazki_ID_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Ksiazki_ID_seq"', 5, true);


--
-- TOC entry 4877 (class 0 OID 0)
-- Dependencies: 225
-- Name: Zamowienia_ID_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Zamowienia_ID_seq"', 5, true);


--
-- TOC entry 4878 (class 0 OID 0)
-- Dependencies: 227
-- Name: Zamowienia_Ksiazki_ID_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Zamowienia_Ksiazki_ID_seq"', 8, true);


--
-- TOC entry 4679 (class 2606 OID 34308)
-- Name: Adres Adres_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Adres"
    ADD CONSTRAINT "Adres_pkey" PRIMARY KEY ("ID");


--
-- TOC entry 4693 (class 2606 OID 34383)
-- Name: Autorzy_Ksiazki Autorzy_Ksiazki_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Autorzy_Ksiazki"
    ADD CONSTRAINT "Autorzy_Ksiazki_pkey" PRIMARY KEY ("ID");


--
-- TOC entry 4685 (class 2606 OID 34333)
-- Name: Autorzy Autorzy_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Autorzy"
    ADD CONSTRAINT "Autorzy_pkey" PRIMARY KEY ("ID");


--
-- TOC entry 4681 (class 2606 OID 34319)
-- Name: Klienci Klienci_email_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Klienci"
    ADD CONSTRAINT "Klienci_email_key" UNIQUE (email);


--
-- TOC entry 4683 (class 2606 OID 34317)
-- Name: Klienci Klienci_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Klienci"
    ADD CONSTRAINT "Klienci_pkey" PRIMARY KEY ("ID");


--
-- TOC entry 4687 (class 2606 OID 34342)
-- Name: Ksiazki Ksiazki_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Ksiazki"
    ADD CONSTRAINT "Ksiazki_pkey" PRIMARY KEY ("ID");


--
-- TOC entry 4691 (class 2606 OID 34366)
-- Name: Zamowienia_Ksiazki Zamowienia_Ksiazki_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Zamowienia_Ksiazki"
    ADD CONSTRAINT "Zamowienia_Ksiazki_pkey" PRIMARY KEY ("ID");


--
-- TOC entry 4689 (class 2606 OID 34354)
-- Name: Zamowienia Zamowienia_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Zamowienia"
    ADD CONSTRAINT "Zamowienia_pkey" PRIMARY KEY ("ID");


--
-- TOC entry 4699 (class 2606 OID 34384)
-- Name: Autorzy_Ksiazki Autorzy_Ksiazki_ID_Autora_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Autorzy_Ksiazki"
    ADD CONSTRAINT "Autorzy_Ksiazki_ID_Autora_fkey" FOREIGN KEY ("ID_Autora") REFERENCES public."Autorzy"("ID");


--
-- TOC entry 4700 (class 2606 OID 34389)
-- Name: Autorzy_Ksiazki Autorzy_Ksiazki_ID_Ksiazki_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Autorzy_Ksiazki"
    ADD CONSTRAINT "Autorzy_Ksiazki_ID_Ksiazki_fkey" FOREIGN KEY ("ID_Ksiazki") REFERENCES public."Ksiazki"("ID");


--
-- TOC entry 4694 (class 2606 OID 34320)
-- Name: Klienci Klienci_ID_Adresu_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Klienci"
    ADD CONSTRAINT "Klienci_ID_Adresu_fkey" FOREIGN KEY ("ID_Adresu") REFERENCES public."Adres"("ID");


--
-- TOC entry 4695 (class 2606 OID 34343)
-- Name: Ksiazki Ksiazki_ID_Autora_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Ksiazki"
    ADD CONSTRAINT "Ksiazki_ID_Autora_fkey" FOREIGN KEY ("ID_Autora") REFERENCES public."Autorzy"("ID");


--
-- TOC entry 4696 (class 2606 OID 34355)
-- Name: Zamowienia Zamowienia_ID_Klienta_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Zamowienia"
    ADD CONSTRAINT "Zamowienia_ID_Klienta_fkey" FOREIGN KEY ("ID_Klienta") REFERENCES public."Klienci"("ID");


--
-- TOC entry 4697 (class 2606 OID 34372)
-- Name: Zamowienia_Ksiazki Zamowienia_Ksiazki_ID_Ksiazki_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Zamowienia_Ksiazki"
    ADD CONSTRAINT "Zamowienia_Ksiazki_ID_Ksiazki_fkey" FOREIGN KEY ("ID_Ksiazki") REFERENCES public."Ksiazki"("ID");


--
-- TOC entry 4698 (class 2606 OID 34367)
-- Name: Zamowienia_Ksiazki Zamowienia_Ksiazki_ID_Zamowienia_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Zamowienia_Ksiazki"
    ADD CONSTRAINT "Zamowienia_Ksiazki_ID_Zamowienia_fkey" FOREIGN KEY ("ID_Zamowienia") REFERENCES public."Zamowienia"("ID");


-- Completed on 2025-04-19 16:11:30

--
-- PostgreSQL database dump complete
--

