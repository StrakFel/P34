import requests

years = 2024
country = 'UA'

url = f'https://date.nager.at/api/v3/PublicHolidays/{years}/{country}'
response = requests.get(url)

if response.ok:
    as_json = response.json()
    for holiday in as_json:
        print(f'Дата:{holiday['date']}, назва:{holiday['localName']};')
else:
    print('Щось прішло не так')
    print(f'{response.status_code=}')