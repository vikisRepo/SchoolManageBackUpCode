import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validator } from '@angular/forms';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { ConstantPool } from '@angular/compiler';
import { SSL_OP_NO_TLSv1_1 } from 'constants';
import { ShowHideDirective } from '@angular/flex-layout';
import { $ } from 'protractor';
import { ViewChild } from '@angular/core';
import { AngularFileUploaderComponent } from "angular-file-uploader";
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { FormTouched } from 'src/app/shared/interfaces/form-touched';


@Component({
  selector: 'app-document',
  templateUrl: './document.component.html',
  styleUrls: ['./document.component.css']
})
export class DocumentComponent implements OnInit ,FormTouched{
  @Output() stuFormDetails = new EventEmitter();
  documentForm: FormGroup;
  selectedFile: any = null;
  result: any = null;
  t1img: boolean = false;
  bSuccessImages: boolean = false;
  t1fileName: any = null;
  bCertificareName: any = null;
  passportName: any = null;
  aadharName: any = null;
  RationCardName: any = null;
  all_files: File[] = Array();
  resetVar: any = true;
  imgPath: any = null;
  @BlockUI() blockUI: NgBlockUI;

  attachementTitles=[
  "Transfer Certificate","Birth Certificate","Passport","Aadhaar","Ration Card","Student Visa"
  ]

  @ViewChild('fileUpload1')
  private fileUpload1: AngularFileUploaderComponent;

  public response: { dbPath: '' };


  afuConfig = {
    multiple: false,
    formatsAllowed: ".jpg,.png",
    maxSize: "1",
    uploadAPI: {
      url: "api/api/upload",
      method: "POST",
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

  constructor(private http: HttpClient, private fb: FormBuilder) {
    this.documentForm = this.fb.group({
      transferCertificate: ['']
      , birthCertificate: ['']
      , passport: ['']
      , aadhar: ['']
      , rationCard: ['']
      , studentVisa: ['']
    });
    this.documentForm.valueChanges.subscribe(() => {
      this.stuFormDetails.emit({ value: this.documentForm, valid: this.documentForm.valid });
    })
  }
  formTouched(): boolean {
    this.documentForm.markAllAsTouched();
    return this.documentForm.valid;
  }
  onSubmit() {
    console.warn(this.documentForm.value);
  }
  Onfilesave(event: any, count: any) {

    // this.all_files.push(<File>event.target.files[count][0]);
    // switch(count)
    // {
    //   case 0:
    //     {
    //       this.t1img=true;
    //       this.t1fileName=this.all_files[0].name
    //     }
    //     break;
    //     case 1:
    //     {
    //       this.bSuccessImages=true;
    //       this.bCertificareName=this.all_files[1].name
    //     }
    //     break;
    //     case 2:
    //     {

    //       this.passportName=this.all_files[2].name
    //     }
    //     break;
    //     case 3:
    //     {

    //       this.aadharName=this.all_files[3].name
    //     }
    //     break;
    //     case 4:
    //     {

    //       this.RationCardName=this.all_files[4].name
    //     }
    //     break;
    // }


    // if(count===0)
    // {
    //   this.t1img=true;
    //   this.t1fileName=this.all_files[count].name
    // }
    // this.all_files.push(event.target.files[count]);
    // this.selectedFile =<File>event.target.files[count];
    // console.log(this.selectedFile.name+" "+this.t1img);
    // this.t1fileName=this.selectedFile.name;

    for (let i = 0; i < this.all_files.length; i++) {
      // console.log('File:', this.all_files[i], 'Name:', this.all_files[i].name);
    }

  }

  public uploadFinished = (event) => {
    this.response = event;
    this.imgPath = this.response.dbPath;
  }

  ngOnInit(): void {
  }
  // backTab(index:number)
  // {

  // }
  OnUpload() {
    this.blockUI.start();
    const fd = new FormData();
    fd.append('image', this.selectedFile, this.selectedFile.name);
    this.http.post('', fd).subscribe(res => {
      console.log(res);
    });
this.blockUI.stop();
  }



}
