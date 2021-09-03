import { Component, OnInit, Output,EventEmitter, ViewChild, CUSTOM_ELEMENTS_SCHEMA  } from '@angular/core';
import { AngularFileUploaderComponent } from 'angular-file-uploader';
import { LoginUser } from 'src/app/login-form/login-user';
import { AuthenticationService } from 'src/app/login-form/service/authentication.service';
import { AccountService } from '../../../_services';


@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  shouldRun=false;
 
  isSmScreen=false;

  imgPath: any = null;

  loginuser : LoginUser = new LoginUser();

  selectedFile: any= null;

  account = this.accountService.accountValue;

  @Output() menuToggle=new EventEmitter<boolean>();
   private menuFlag:boolean=false;

   @ViewChild('fileUpload1')
   private fileUpload1:  AngularFileUploaderComponent;

   public response: {dbPath: ''};


   afuConfig = {
     multiple: false,
     formatsAllowed: ".jpg,.png",
     maxSize: "1",
     uploadAPI:  {
       url:"api/api/upload",
       method:"POST",
     //   headers: {
     //  "Content-Type" : "text/plain;charset=UTF-8",
     //   },
       params: {
         'page': '1'
       },
       responseType: 'blob',
     },
     theme: "attachPin",
     hideProgressBar: true,
     hideResetBtn: true,
     hideSelectBtn: true,
     fileNameIndex: true,
     replaceTexts: {
       selectFileBtn: 'Select Files',
       resetBtn: 'Reset',
       uploadBtn: 'Upload',
       dragNDropBox: 'Drag N Drop',
       attachPinBtn: 'Attach Files...',
       afterUploadMsg_success: 'Successfully Uploaded !',
       afterUploadMsg_error: 'Upload Failed !',
       sizeLimit: 'Size Limit'
     }
 };
  http: any;
  
  
  constructor(private loginApiService: AuthenticationService, private accountService: AccountService) { 
    console.log(this.loginApiService.userValue);
    this.loginuser = this.loginApiService.userValue;
    console.log(this.loginuser.firstName);
  }

  ngOnInit(): void {
    //For Mobile page demo
   this.isSmScreen= window.matchMedia('(max-width: 600px)').matches;
   console.log(this.isSmScreen)
  }

  menuToggleAction(){
    this.menuFlag=!this.menuFlag;
    this.menuToggle.emit(this.menuFlag);
  }
  public uploadFinished = (event) => {
    this.response = event;
    this.imgPath = this.response.dbPath;
  }
  OnUpload()
  {
    const fd= new FormData();
    fd.append('image',this.selectedFile,this.selectedFile.name);
    this.http.post('',fd).subscribe(res=>{
    console.log(res);
    });
  }

  public createImgPath = (serverPath: string) => {
    return `api/api/${serverPath}`;
  }

  logout() {
    this.accountService.logout();
  }

}
