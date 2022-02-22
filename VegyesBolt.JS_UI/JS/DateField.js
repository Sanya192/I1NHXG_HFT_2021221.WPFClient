class DateField extends StandardField {
  constructor(value) {
    super(value);
  }

  getValue() {
    return Date.parse(this._value);
  }
}
