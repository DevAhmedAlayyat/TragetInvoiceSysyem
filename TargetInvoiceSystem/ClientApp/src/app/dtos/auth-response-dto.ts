export class AuthResponseDto {
    message: string;
    isSuccess: boolean;
    errors: string[];
    token: string;
    tokenExpireDate: Date;
}
