

class StringFormatter(object):

    def __init__(self, text):
        self._text = text

    def del_word(self, n):
        return ' '.join([word for word in self._text.split(' ') if len(word) > n])

    def replace_digit(self):
        return self._text.translate(self._text.maketrans("123456789","*********"))

    def insert_space(self):
        return '  '.join([word for word in self._text.split(' ')])

    def sort_size(self):
        return ' '.join(sorted(self._text.split(), key = lambda word: len(word)))

    def sort_alphabet(self):
        return ' '.join(sorted(self._text.split()))


