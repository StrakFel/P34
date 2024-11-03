import asyncio
import logging
from aiogram import Bot, Dispatcher, types
from aiogram.filters.command import Command, CommandObject
import random

logging.basicConfig(level=logging.INFO)
bot = Bot(token="6542016047:AAGgCr5AWUjDR8SGFbTwaNq0gvOF-TVERJM")
dp = Dispatcher()


@dp.message(Command("start"))
async def cmd_start(message: types.Message):
    await message.answer("Hello!")


@dp.message(Command("help"))
async def cmd_help(message: types.Message):
    await message.answer(
        "/help — отримати довідку за командами\n"
        "/roll — генерація випадкового числа"
    )


@dp.message(Command("roll"))
async def cmd_roll(message: types.Message, command: CommandObject):
    if command.args is not None:
        args = command.args.split()
        await message.answer(f'Випадкове число від 1 до {args[0]}: {random.randint(1, int(args[0]))}')
    else:
        await message.answer(f'Випадкове число від 1 до 100: {random.randint(1, 100)}')


@dp.message()
async def all_messages(message: types.Message):
    print(f'{message.from_user.full_name} (id: {message.from_user.id}): {message.text}')



async def main():
    await dp.start_polling(bot)


if __name__ == "__main__":
    asyncio.run(main())
