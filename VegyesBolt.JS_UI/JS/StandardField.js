/**
 * A field which data we don't wanna process specially.
 */
class StandardField {
  _value;
  constructor(value) {
    this._value = value;
  }

  getValue() {
    return this._value;
  }
}
