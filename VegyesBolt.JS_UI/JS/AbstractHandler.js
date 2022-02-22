class AbstractHandler {
  map;
  constructor() {
    if (this.constructor == AbstractHandler)
      throw new Error("This is an Abstract class");
  }

  /**
   * Supposed to be an array that includes the fields to go through. Only implemented in child class.
   * @protected
   */
  _variablesToIterateThrough;

  /**
   *
   * @returns {Generator<*, StandardField, *>}
   */
  *[Symbol.iterator]() {
    for (let i = 0; i < this._variablesToIterateThrough.length; i++) {
      yield this._variablesToIterateThrough[i];
    }
  }

  HeaderString = () => {};
}
