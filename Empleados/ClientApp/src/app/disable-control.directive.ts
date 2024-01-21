import { Directive, Input } from '@angular/core';
import { NgControl } from '@angular/forms';

@Directive({
  selector: `
    [formControl][disableControl],
    [formControlName][disableControl]
  `,
  standalone: true,
})

export class DisableControlDirective {

  @Input() set disableControl(condition: boolean) {
    const control = this.ngContrl.control;
    condition ? control?.disable() : control?.enable();
  }

  constructor(private ngContrl: NgControl) { }

}
