#include <iostream>
#include <fstream>
#include <string>

using namespace std;

int main() {
    string word;
    cout << "Enter word: ";
    cin >> word;

    string reversed_word;
    for (int i = word.size() - 1; i >= 0; --i) {
        reversed_word += word[i];
    }

    ofstream file("words.txt", ios::app);
    if (file.is_open()) {
        file << reversed_word << "\n";
        file.close();
        cout << "Word \"" << reversed_word << "\" written to file words.txt.\n";
    }
    else {
        cerr << "Could not open file for writing\n";
    }

    return 0;
}
