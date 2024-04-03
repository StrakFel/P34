while True:
    trophies = int(input('Введите количество кубков на бойце: '))
    if trophies < 0:
        print('Введено неправильное количество кубков')
    elif trophies < 500:
        print('Вы еще не получили 20 ранг')
    elif trophies == 500:
        print('Вам нужно минимум 501 трофей')
    elif trophies > 500 and trophies < 525:
        print('Вы получите 4 блинга')
    elif trophies > 524 and trophies < 550:
        print('Вы получите 6 блингов')
    elif trophies > 549 and trophies < 575:
        print('Вы получите 8 блингов')
    elif trophies > 574 and trophies < 600:
        print('Вы получите 10 блингов')
    elif trophies > 599 and trophies < 625:
        print('Вы получите 12 блингов')
    elif trophies > 624 and trophies < 650:
        print('Вы получите 14 блингов')
    elif trophies > 649 and trophies < 675:
        print('Вы получите 16 блингов')
    elif trophies > 674 and trophies < 700:
        print('Вы получите 18 блингов')
    elif trophies > 699 and trophies < 725:
        print('Вы получите 20 блингов')
    elif trophies > 724 and trophies < 750:
        print('Вы получите 22 блингов')
    elif trophies > 749 and trophies < 775:
        print('Вы получите 24 блингов')
    elif trophies > 774 and trophies < 800:
        print('Вы получите 26 блингов')
    elif trophies > 779 and trophies < 825:
        print('Вы получите 28 блингов')
    elif trophies > 824 and trophies < 850:
        print('Вы получите 30 блингов')
    elif trophies > 849 and trophies < 875:
        print('Вы получите 32 блингов')
    elif trophies > 874 and trophies < 900:
        print('Вы получите 34 блингов')
    elif trophies > 899 and trophies < 925:
        print('Вы получите 36 блингов')
    elif trophies > 924 and trophies < 950:
        print('Вы получите 38 блингов')
    elif trophies > 949 and trophies < 975:
        print('Вы получите 40 блингов')
    elif trophies > 974 and trophies < 1000:
        print('Вы получите 42 блингов')
    elif trophies > 999 and trophies < 1050:
        print('Вы получите 44 блингов')
    elif trophies > 1049 and trophies < 1100:
        print('Вы получите 46 блингов')
    elif trophies > 1099 and trophies < 1150:
        print('Вы получите 48 блингов')
    elif trophies > 1149 and trophies < 1200:
        print('Вы получите 50 блингов')
    elif trophies > 1199 and trophies < 1250:
        print('Вы получите 52 блингов')
    elif trophies > 1249 and trophies < 1300:
        print('Вы получите 54 блингов')
    elif trophies > 1299 and trophies < 1350:
        print('Вы получите 56 блингов')
    elif trophies > 1349 and trophies < 1400:
        print('Вы получите 58 блингов')
    elif trophies > 1399 and trophies < 1450:
        print('Вы получите 60 блингов')
    elif trophies > 1449 and trophies < 1500:
        print('Вы получите 62 блингов')
    elif trophies > 1500:
        print('Вы получите 64 блингов')