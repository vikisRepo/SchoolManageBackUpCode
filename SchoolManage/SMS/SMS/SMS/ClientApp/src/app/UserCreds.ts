export class UserCreds {

    constructor(
      public id: number,
      public name: string,
      public password: string,
      public _jwtToken: string
    ) {  }
  
  }