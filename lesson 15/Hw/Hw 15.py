import random


def choose_item(bot=False):
    if bot:
        return random.choice(['к', 'н', 'п'])
    else:
        choice = input('Виберіть камінь(к), ножиці(н),папір(п) або введіть 0 щоб завершити гру: ').lower()
        while choice not in ['к', 'н', 'п', '0']:
            print('Недопустиме значення, напишіть правильно!')
            choice = input('Виберіть камінь(к), ножиці(н) або папір(п), або введіть 0 щоб завершити гру: ').lower()
        return choice


def full_name(item):
    if item == 'к':
        return 'Каміння'
    elif item == 'н':
        return 'Ножиці'
    elif item == 'п':
        return 'Папір'


def claim_winner(player, bot):
    if player == bot:
        return 'd'
    elif (player == 'к' and bot == 'н') or (player == 'н' and bot == 'п') or (player == 'п' and bot == 'к'):
        return 'player'
    else:
        return 'bot'


def main_game():
    print('Гра "Каміння Ножиці Папір"')
    player_choice = choose_item(bot=False)
    if player_choice == '0':
        print('\nДякую за гру!')
        return True
    bot_choice = choose_item(bot=True)
    print(f'-Ваш вибір: {full_name(player_choice)}')
    print(f'-Вибір комп`ютера: {full_name(bot_choice)}')
    winner = claim_winner(player_choice, bot_choice)
    if winner == 'player':
        print('       Ви перемогли!\n')
    elif winner == 'bot':
        print('    Комп`ютер переміг!\n')
    else:
        print('          Нічия!\n')


if __name__ == '__main__':
    while True:
        if main_game():
            break