import requests

url = 'https://www.whenisthenextmcufilm.com/api'
response = requests.get(url)

if response.ok:
    as_json = response.json()
    print('       When is the next MCU film?')
    print(f"{as_json['title']} releases in {as_json['days_until']} days!")
    print(f'        Release Date: {as_json['release_date']}')
    print(f'         Production Type: {as_json['type']}')
    print(f"What's afterwards? {as_json['following_production']['title']}")
    print(f'{as_json['poster_url']}')
else:
    print('Щось прішло не так')
    print(f'{response.status_code=}')

